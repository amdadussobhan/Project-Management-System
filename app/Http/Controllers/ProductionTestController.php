<?php

namespace App\Http\Controllers;

use App\Log;
use App\ProductionTest;
use App\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

use function PHPSTORM_META\override;

class ProductionTestController extends Controller
{
    public function production_tests(Request $request)
    {
        $logs = Log::where('JobId','Like','%Test22')->where('ischecked', '0')->groupBy('Name')->get();
        $advances = ProductionTest::Where('Team', 'Advance')->Orderby('name', 'asc')->get();
        $basics = ProductionTest::Where('Team', 'Basic')->Orderby('name', 'asc')->get();
        $seniors = ProductionTest::Where('Team', 'Senior')->Orderby('name', 'asc')->get();
        $clippers = ProductionTest::Where('Team', 'Clipper')->Orderby('name', 'asc')->get();
        $team = "";
        $designers = "";
        $designer = "";
        $users = "";
        $user_id = "";
        
        return view("reader.page.increment_test.production_tests", compact(['advances','basics','seniors','clippers', 'logs', 'designers', 'designer',
            'users', 'user_id', 'team']));
    }

    public function production_test(Request $request)
    {
        $user_id = Auth::user()->id;
        
        if($user_id != 5 & $user_id != 10 & $user_id != 1111)
            return redirect()->back();

        $row = ProductionTest::find($request->input('id'));
        $team = "";
        $designers = "";
        $designer = "";
        $users = "";
        $user_id = "";
        return view("reader.page.increment_test.production_test", compact(['row', 'designers', 'designer',
            'users', 'user_id', 'team']));
    }

    public function production_test_print(Request $request)
    {
        $user_id = Auth::user()->id;
        
        if($user_id != 5 & $user_id != 10 & $user_id != 1111)
            return redirect()->back();

        $row = ProductionTest::find($request->input('id'));
        $team = "";
        $designers = "";
        $designer = "";
        $users = "";
        $user_id = "";
        return view("reader.page.increment_test.print", compact(['row', 'designers', 'designer',
            'users', 'user_id', 'team']));
    }
    
    public function add_efficiency(Request $request)
    {
        $name = $request->name;
        $log_id = $request->log_id;
        $increment_id = $request->increment_id;

        $log = Log::find($log_id);

        if($increment_id != "" & $increment_id != null){
            $increment = ProductionTest::find($increment_id);
            $name = $increment->name;
        }else{
            $increment = ProductionTest::where('name', $name)->first();

            if($increment == null){
                $increment = new ProductionTest();
                $increment->name = $name;
            }else{
                $increment = ProductionTest::find($increment->id);
            }
        }

        $target_time = Log::where('Name', $name)->where('JobId', 'Like', '%Test22%')->sum('TargetTime');
        $pro_time = Log::where('Name', $name)->where('JobId', 'Like', '%Test22%')->sum('ProTime');

        $increment->efficiency = ($target_time / $pro_time) * 100;
        $increment->performance = $request->performance;
        $increment->team = $log->Team;

        $user = User::where('label', $name)->first();

        $increment->full_name = $user->name;
        $increment->employee_id = $user->employee_id;
        $increment->designation = $user->designation;

        if ($increment->save())
        {
            $test22 = Log::where("Name", $log->Name)->where('JobId', 'Like', '%Test22%')->update(["ischecked" => 1]);
            return redirect()->back()->with('success', 'Remarks Save Successfully.');
        }
        else
            return redirect()->back()->with('error', 'Oops!... Something went wrong. Please try again.');
    }
    
    public function edit_efficiency(Request $request)
    {
        $production_test_id = $request->production_test_id;
        $production_test = ProductionTest::find($production_test_id);
        
        $target_time = Log::where('Name', $production_test->name)->where('JobId', 'Like', '%Test22%')->sum('TargetTime');
        $pro_time = Log::where('Name', $production_test->name)->where('JobId', 'Like', '%Test22%')->sum('ProTime');

        $production_test->efficiency = ($target_time / $pro_time * 100);
        $production_test->performance = $request->performance;

        if ($production_test->save())
            return redirect()->back()->with('success', 'Remarks Save Successfully.');
        else
            return redirect()->back()->with('error', 'Oops!... Something went wrong. Please try again.');
    }
    
    public function si_feedback(Request $request)
    {
        $user_id = Auth::user()->id;
        $increment_id = $request->si_increment_id;
        $quality = $request->quality;
        $interest = $request->interest;
        $discipline = $request->discipline;
        $dedication = $request->dedication;

        $production_test = ProductionTest::find($increment_id);

        if($user_id == 11){
            $production_test->quality_sumon = $quality;
            $production_test->interest_sumon = $interest;
            $production_test->discipline_sumon = $discipline;
            $production_test->dedication_sumon = $dedication;
        }else{
            $production_test->quality_mottaleb = $quality;
            $production_test->interest_mottaleb = $interest;
            $production_test->discipline_mottaleb = $discipline;
            $production_test->dedication_mottaleb = $dedication;
        }

        $production_test->quality_overall = $this->overall_si($production_test->quality_sumon, $production_test->quality_mottaleb);
        $production_test->interest_overall = $this->overall_si($production_test->interest_sumon, $production_test->interest_mottaleb);
        $production_test->discipline_overall = $this->overall_si($production_test->discipline_sumon, $production_test->discipline_mottaleb);
        $production_test->dedication_overall = $this->overall_si($production_test->dedication_sumon, $production_test->dedication_mottaleb);

        $overall = $this->overall($production_test->quality_sumon, $production_test->quality_mottaleb, $production_test->interest_sumon, 
            $production_test->interest_mottaleb, $production_test->discipline_sumon, $production_test->discipline_mottaleb, 
            $production_test->dedication_sumon, $production_test->dedication_mottaleb);

        $production_test->overall = $overall;

        if ($production_test->save())
            return redirect()->back()->with('success', 'Feedback Save Successfully.');
        else
            return redirect()->back()->with('error', 'Oops!... Something went wrong. Please try again.');
    }

    public function overall_si($sumon, $mottaleb)
    {
        $overall = null;

        if($sumon != null & $mottaleb != null){
            $value = ($this->grade_to_value($sumon) + $this->grade_to_value($mottaleb)) / 2;
            $overall = $this->value_to_grade($value);
        }

        return $overall;
    }

    public function overall($quality_sumon, $quality_mottaleb, $interest_sumon, $interest_mottaleb, $discipline_sumon, $discipline_mottaleb, $dedication_sumon, $dedication_mottaleb)
    {
        $overall = null;

        if($quality_sumon != null & $quality_mottaleb != null & $interest_sumon != null & $interest_mottaleb != null & $discipline_sumon != null& $discipline_mottaleb != null& $dedication_sumon != null& $dedication_mottaleb != null){
            $value = ($this->grade_to_value($quality_sumon) + $this->grade_to_value($quality_mottaleb) + $this->grade_to_value($interest_sumon) + $this->grade_to_value($interest_mottaleb) + $this->grade_to_value($discipline_sumon)+ $this->grade_to_value($discipline_mottaleb)+ $this->grade_to_value($dedication_sumon)+ $this->grade_to_value($dedication_mottaleb)) / 8;
            $overall = $this->value_to_grade($value);
        }

        return $overall;
    }

    public function grade_to_value($grade)
    {
        if($grade == 'A')
            return 5;
        else if($grade == 'B')
            return 4;
        else if($grade == 'C')
            return 3;
        else if($grade == 'D')
            return 2;
        else
            return 1;
    }

    public function value_to_grade($value)
    {
        if($value >= 5)
            return 'A';
        else if($value >= 4)
            return 'B';
        else if($value >= 3)
            return 'C';
        else if($value >= 2)
            return 'D';
        else
            return 'E';
    }      
    
    public function hr_feedback(Request $request)
    {
        $production_test = ProductionTest::find($request->hr_increment_id);
        
        $production_test->joining_date = $request->date;
        $production_test->salary = $request->salary;
        $production_test->attendence = $request->attendence;
        $production_test->increment_hr = $request->amount;
        $production_test->remarks_hr = $request->remarks;

        if ($production_test->save())
            return redirect()->back()->with('success', 'Remarks Save Successfully.');
        else
            return redirect()->back()->with('error', 'Oops!... Something went wrong. Please try again.');
    }

    public function increment(Request $request)
    {
        $user_id = Auth::user()->id;
        $production_test = ProductionTest::find($request->increment_id);
        
        if($user_id == 130){
            $production_test->increment_spm = $request->amount;
            $production_test->remarks_spm = $request->remarks;
        }

        if($user_id == 8){
            $production_test->increment_qpm = $request->amount;
            $production_test->remarks_qpm = $request->remarks;
        }

        if($user_id == 10){
            $production_test->increment_hr = $request->amount;
            $production_test->remarks_hr = $request->remarks;
        }

        if($user_id == 5){
            $production_test->increment_ho = $request->amount;
            $production_test->remarks_ho = $request->remarks;
        }

        if ($production_test->save())
            return redirect()->back()->with('success', 'Remarks Save Successfully.');
        else
            return redirect()->back()->with('error', 'Oops!... Something went wrong. Please try again.');
    }
    
    public function test_report(Request $request){
        $rows = Log::where('JobId', 'Like', '%Test22')->where('Name', $request->input('name'))->get();
        return view('reader.page.increment_test.test_report', compact(['rows']));
    }
}
