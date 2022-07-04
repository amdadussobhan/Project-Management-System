<?php

namespace App\Http\Controllers;

use App\Account;
use App\NewJob;
use App\Workorder;
use Carbon\Carbon;
use Illuminate\Http\Request;
use Maatwebsite\Excel\Row;

class AccountController extends Controller
{
    public function dashboard()
    {
        return view("accounts.page.dashboard", compact([]));
    }

    public function index()
    {
        //
    }

    public function workorder($workorder)
    {
        $clients = NewJob::OrderBy('SL','desc')
            ->where('Date', '>', Carbon::now()->addDay(-111))
            ->distinct()->get(['Client']);

        $workorder = Workorder::find($workorder);
        $first_date = date_create($workorder->month)->modify('first day of this month')->format('Y-m-d');
        $last_date = date_create($workorder->month)->modify('last day of this month')->format('Y-m-d');
        
        $rows = NewJob::where('Loc', "DHK")
            ->where('Client', $workorder->skill_code)
            ->whereBetween('Delivery', [$first_date, $last_date])
            ->OrderBy('Delivery','asc')
            ->get();

        $TotalQnt = NewJob::where('Loc', "DHK")
            ->where('Client', $workorder->skill_code)
            ->whereBetween('Delivery', [$first_date, $last_date])
            ->sum('OutputAmount');
        
        return view("accounts.page.workorder.workorder", compact(['workorder', 'TotalQnt', 'rows', 'clients']));
    }

    public function workorders()
    {
        $clients = NewJob::OrderBy('SL','desc')
            ->where('Date', '>', Carbon::now()->addDay(-111))
            ->distinct()->get(['Client']);
        
        $rows = Workorder::OrderBy('month','desc')->paginate(99);
        return view("accounts.page.workorder.workorders", compact(['rows', 'clients']));
    }
    
    public function create()
    {
        //
    }
    
    public function store(Request $request)
    {
        //
    }
    
    public function show(Account $account)
    {
        //
    }
    
    public function edit(Account $account)
    {
        //
    }
    
    public function update(Request $request, Account $account)
    {
        //
    }
    
    public function destroy(Account $account)
    {
        //
    }
}
