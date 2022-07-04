<?php

namespace App\Http\Controllers;

use App\Client;
use App\NewJob;
use App\Workorder;
use Illuminate\Http\Request;
use PDF;

class WorkorderController extends Controller
{
    public function index()
    {
        //
    }

    public function client(Request $request){
        if ($request->ajax()){
            $find = $request->get('find');
            if ($find != ''){
                $data = Client::where('code', $find)->get();
                
                if ($data->count() > 0)
                    echo $data[0];
                else
                    echo 'No';
            }
        }
    }
    
    public function print($workorder)
    {
        $workorder = Workorder::find($workorder);
        $first_date = date_create($workorder->month)->modify('first day of this month')->format('Y-m-d');
        $last_date = date_create($workorder->month)->modify('last day of this month')->format('Y-m-d');
        
        $rows = NewJob::where('Loc', "DHK")
            ->where('Client', $workorder->skill_code)
            ->whereBetween('Delivery', [$first_date, $last_date])
            ->get();

        $TotalQnt = NewJob::where('Loc', "DHK")
            ->where('Client', $workorder->skill_code)
            ->whereBetween('Delivery', [$first_date, $last_date])
            ->sum('OutputAmount');

        $workorder->total_quantity = $TotalQnt;
        $workorder->save();
            
        return view("accounts.page.workorder.print", compact(['workorder', 'TotalQnt', 'rows']));
    }

    public function downloadPDF($id){
      $user = Workorder::find($id);

      $pdf = PDF::loadView('accounts.page.workorder.pdf', compact('user'));
      return $pdf->download('invoice.pdf');
    }

    // Generate PDF
    public function CreatePDF($workorder) {
        // retreive all records from db
        $workorder = Workorder::find($workorder);
        $first_date = date_create($workorder->month)->modify('first day of this month')->format('Y-m-d');
        $last_date = date_create($workorder->month)->modify('last day of this month')->format('Y-m-d');

        $data = NewJob::where('Loc', "DHK")
          ->where('Client', $workorder->skill_code)
          ->whereBetween('Delivery', [$first_date, $last_date])
          ->get();

      // share data to view
      view()->share('rows', $data);

      $pdf = PDF::loadView('accounts.page.workorder.workorder', compact(['workorder', 'TotalQnt', 'rows', 'data']));
      // download PDF file with download method
      return $pdf->download('workorder.pdf');
    }
    
    public function itemPdfView(Request $request)  
    {
        $workorder = Workorder::find(15);
        $first_date = date_create($workorder->month)->modify('first day of this month')->format('Y-m-d');
        $last_date = date_create($workorder->month)->modify('last day of this month')->format('Y-m-d');

        $items = NewJob::where('Loc', "DHK")
          ->where('Client', $workorder->skill_code)
          ->whereBetween('Delivery', [$first_date, $last_date])
          ->get();
 
        view()->share('items', $items);  
  
        if($request->has('download')){  
            $pdf = PDF::loadView('accounts.page.workorder.itemPdfView');  
            return $pdf->download('itemPdfView.pdf');  
        }      
        return view('accounts.page.workorder.itemPdfView');  
    }

    public function generatePDF()
    {
        $data = ['title' => 'Welcome to ItSolutionStuff.com'];
        $pdf = PDF::loadView('accounts.page.workorder.myPDF', $data);

        return $pdf->download('itsolutionstuff.pdf');
    }
    
    public function create()
    {
        //
    }
    
    public function store(Request $request)
    {
        $workorder = new Workorder();
        $workorder->name = $request->input('company_name');
        $workorder->skill_code = $request->input('client');
        $workorder->month = $request->input('month');
        $workorder->ref_id = $request->input('ref_id');
        $workorder->sl = $request->input('code');
        $workorder->address = $request->input('address');

        if($workorder->save())
            return redirect('/4/workorder/' . $workorder->id)->with('Success', 'New Workorder Created Successfully');
        else
            return redirect()->back()->with('error', 'Oops!... Workorder Can not Created. Please try again.');
    }
    
    public function show(Workorder $workorder)
    {
        //
    }
    
    public function edit(Workorder $workorder)
    {
        //
    }
    
    public function update(Request $request, Workorder $workorder)
    {
        //
    }
    
    public function destroy(Workorder $workorder)
    {
        //
    }
}
