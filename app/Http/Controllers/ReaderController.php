<?php

namespace App\Http\Controllers;

use App\Feedback;
use App\Log;
use App\NewJob;
use App\Performance;
use App\ProductionTest;
use App\RunningJob;
use App\ShiftReport;
use App\User;
use App\WorkLoad;
use Carbon\Carbon;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\DB;
use phpDocumentor\Reflection\Types\Collection;
use function Complex\add;

class ReaderController extends Controller
{
    public function dashboard_old(Request $request){
        $date = Carbon::today();
        $date = $date->format('Y-m-d');
        $user_id = Auth::user()->id;

        if($request->has('team'))
            $team = $request->input('team');
        else
            $team = "DHK";

        if ($user_id == 50)
            $team = "NAT";

        if($request->has('date')){
            if (!empty($request->input('date')))
                $date = $request->input('date');
        }

        $Morning_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'07:00:00');
        $Evening_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'15:00:00');
        $Night_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'23:00:00');

        $shift = 'Night';

        if (Carbon::now() > $Morning_Start)
            $shift = 'Morning';

        if (Carbon::now() > $Evening_Start)
            $shift = 'Evening';

        if (Carbon::now() > $Night_Start)
            $shift = 'Night';

        if($request->has('shift')){
            $shift = $request->input('shift');
        }

        $row=ShiftReport::where('Date', [$date])
            ->where('team', '')
            ->where('Shift', [$shift])
            ->where('Loc', [$team])
            ->first();

        return view("reader.page.dashboard", compact(['row', 'date', 'shift', 'team']));
    }

    public function workloads(Request $request){
        $date = Carbon::today();
        $date = $date->format('Y-m-d');

        $Morning_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'07:00:00');
        $Evening_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'15:00:00');
        $Night_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'23:00:00');

        $shift = 'Night';
        if (Carbon::now() > $Morning_Start)
            $shift = 'Morning';

        if (Carbon::now() > $Evening_Start)
            $shift = 'Evening';

        if (Carbon::now() > $Night_Start)
            $shift = 'Night';

        if($request->has('shift')){
            if (!empty($request->input('shift'))) {
                $shift = $request->input('shift');
            }
        }

        $date = Carbon::today();
        if($request->has('date')) {
            if (!empty($request->input('date')))
                $date = date_create($request->input('date'));
        }
        $date = $date->format('Y-m-d');

        $date_to = $date;
        if($request->has('date_to')) {
            if (!empty($request->input('date_to')))
                $date_to = date_create($request->input('date_to'));
        }

        $Basic = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'Basic')
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $Advance = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'Advance')
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $QC_Team = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'QC_Team')
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $New_Job = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', '')
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        return view("reader.page.workloads", compact(['Basic', 'Advance', 'QC_Team', 'New_Job', 'shift', 'date']));
    }

    public function capacity(Request $request){
        if($request->has('date')){
            $date = $request->input('date');
        }

        if($request->has('shift')){
            $shift = $request->input('shift');
        }

        $rows=Performance::where('Date', [$date])
            ->where('Shift', [$shift])
            ->orderBy('date', 'desc')
            ->orderBy('Shift','asc')
            ->orderBy('Efficiency','desc')
            ->paginate(50);

        return view("reader.page.performances", compact("rows"));
    }

    public function shift_reports(Request $request)
    {
        $user_id = Auth::user()->id;

        if($request->has('team'))
            $team = $request->input('team');
        else
            $team = "DHK";

        if ($user_id == 50)
            $team = "NAT";

        $rows=ShiftReport::where('Loc', [$team])
            ->where('team', '')
            ->orderBy('date', 'desc')
            ->orderBy('Shift','asc')
            ->orderBy('Efficiency','desc');

        $shift = "";
        if($request->has('shift')){
            if (!empty($request->input('shift'))) {
                $shift = $request->input('shift');
                $rows = $rows->where('Shift', [$shift]);
            }
        }

        $date = Carbon::today();
        if (!empty($request->input('date')))
            $date = date_create($request->input('date'));
        $date = $date->format('Y-m-d');

        if (!empty($request->input('date_to')))
            $date_to = date_create($request->input('date_to'));
        else
            $date_to = Carbon::today();
        $date_to = $date_to->format('Y-m-d');

        $rows=$rows->paginate(100);
        return view("reader.page.shift_reports", compact(["rows", 'shift', 'date', 'date_to', 'team']));
    }

    public function shift_report(Request $request)
    {
        $date = Carbon::today();
        $date = $date->format('Y-m-d');

        $Morning_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'07:00:00');
        $Evening_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'15:00:00');
        $Night_Start = Carbon::createFromFormat('Y-m-d H:i:s',$date.'23:00:00');

        $shift = 'Night';
        if (Carbon::now() > $Morning_Start)
            $shift = 'Morning';

        if (Carbon::now() > $Evening_Start)
            $shift = 'Evening';

        if (Carbon::now() > $Night_Start)
            $shift = 'Night';

        if($request->has('shift')){
            if (!empty($request->input('shift'))) {
                $shift = $request->input('shift');
            }
        }

        $date = Carbon::today();
        if($request->has('date')) {
            if (!empty($request->input('date')))
                $date = date_create($request->input('date'));
        }
        $date = $date->format('Y-m-d');

        $date_to = $date;
        if($request->has('date_to')) {
            if (!empty($request->input('date_to')))
                $date_to = date_create($request->input('date_to'));
        }

        $Basic = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'Basic')
            ->whereNotIn('Output_File', [0])
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $Advance = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'Advance')
            ->whereNotIn('Output_File', [0])
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $QC_Team = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'QC_Team')
            ->whereNotIn('Output_File', [0])
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $Shift_Report = ShiftReport::where('Date', $date)
            ->where('Shift', $shift)
            ->where('Team', '')
            ->first();

        return view("reader.page.shift_report", compact(['Basic', 'Advance', 'QC_Team', 'shift', 'date', 'Shift_Report']));
    }

    public function dashboard(Request $request)
    {
        $date = Carbon::today();
        $date = $date->format('Y-m-d');

        $Morning_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'07:00:00');
        $Evening_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'15:00:00');
        $Night_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'23:00:00');

        $shift = 'Night';
        if (Carbon::now() > $Morning_Start)
            $shift = 'Morning';

        if (Carbon::now() > $Evening_Start)
            $shift = 'Evening';

        if (Carbon::now() > $Night_Start)
            $shift = 'Night';

        if($request->has('shift')){
            if (!empty($request->input('shift'))) {
                $shift = $request->input('shift');
            }
        }
        
        $date = Carbon::today();

        if($request->has('date')) {
            if (!empty($request->input('date')))
                $date = date_create($request->input('date'));
        }

        $date = $date_to = $date->format('Y-m-d');

        $Basic = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'Basic')
            ->whereNotIn('Output_File', [0])
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $Advance = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'Advance')
            ->whereNotIn('Output_File', [0])
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $QC_Team = WorkLoad::join('new_jobs', 'new_jobs.JobId', '=', 'work_loads.JobId')
            ->orderBy('new_jobs.incoming', 'asc')
            ->where('new_jobs.Loc', 'DHK')
            ->where('work_loads.Shift', $shift)
            ->where('work_loads.Team', 'QC_Team')
            ->whereNotIn('Output_File', [0])
            ->whereBetween('work_loads.Date', [$date, $date_to])
            ->get();

        $Shift_Report = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', $shift)
            ->where('Team', '')
            ->first();

        $date_to = date('Y-m-d', strtotime($date. ' - 7 days'));
        $Weekly_Report = ShiftReport::whereBetween('Date', [$date_to, $date])
            ->where('Shift', 'Night')
            ->where('Loc', 'DHK')
            ->orderBy('id', 'desc')
            ->where('Team', '')
            ->get();

        $Current_Morning_Basic = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Morning')
            ->where('Team', 'Basic')
            ->first();

        $Current_Morning_Advance = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Morning')
            ->where('Team', 'Advance')
            ->first();

        $Current_Morning_QC_Team = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Morning')
            ->where('Team', 'QC_Team')
            ->first();

        $Current_Evening_Basic = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Evening')
            ->where('Team', 'Basic')
            ->first();

        $Current_Evening_Advance = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Evening')
            ->where('Team', 'Advance')
            ->first();

        $Current_Evening_QC_Team = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Evening')
            ->where('Team', 'QC_Team')
            ->first();

        $Current_Night_Basic = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Night')
            ->where('Team', 'Basic')
            ->first();

        $Current_Night_Advance = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Night')
            ->where('Team', 'Advance')
            ->first();

        $Current_Night_QC_Team = ShiftReport::where('Date', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Night')
            ->where('Team', 'QC_Team')
            ->first();

        $Last_Morning_Basic = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Morning')
            ->where('Team', 'Basic')
            ->orderBy('id', 'desc')
            ->first();

        $Last_Morning_Advance = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Morning')
            ->where('Team', 'Advance')
            ->orderBy('id', 'desc')
            ->first();

        $Last_Morning_QC_Team = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Morning')
            ->where('Team', 'QC_Team')
            ->orderBy('id', 'desc')
            ->first();

        $Last_Evening_Basic = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Evening')
            ->where('Team', 'Basic')
            ->orderBy('id', 'desc')
            ->first();

        $Last_Evening_Advance = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Evening')
            ->where('Team', 'Advance')
            ->orderBy('id', 'desc')
            ->first();

        $Last_Evening_QC_Team = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Evening')
            ->where('Team', 'QC_Team')
            ->orderBy('id', 'desc')
            ->first();

        $Last_Night_Basic = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Night')
            ->where('Team', 'Basic')
            ->orderBy('id', 'desc')
            ->first();

        $Last_Night_Advance = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Night')
            ->where('Team', 'Advance')
            ->orderBy('id', 'desc')
            ->first();

        $Last_Night_QC_Team = ShiftReport::where('Date', '<', $date)
            ->where('Loc', 'DHK')
            ->where('Shift', 'Night')
            ->where('Team', 'QC_Team')
            ->orderBy('id', 'desc')
            ->first();

        $best_performer = Performance::where('Loc', ['DHK'])
            ->where('Date', $date)
            ->where('Role', '')
            ->where('Shift', $shift)
            ->orderBy('Efficiency','desc')
            ->take(5)->get();

        $bad_performer = Performance::where('Loc', ['DHK'])
            ->where('Date', $date)
            ->where('Role', '')
            ->where('Shift', $shift)
            ->where('Efficiency', '<', 100)
            ->orderBy('Efficiency','asc')
            ->take(5)->get();

        return view("reader.page.dashboard", compact(['Basic', 'Advance', 'QC_Team', 'shift', 'date', 'date_to', 'Shift_Report',
            'Current_Morning_Basic', 'Current_Morning_Advance', 'Current_Morning_QC_Team', 'Current_Evening_Basic', 'Current_Evening_Advance',
            'Current_Evening_QC_Team',  'Current_Night_Basic', 'Current_Night_Advance', 'Current_Night_QC_Team', 'Last_Morning_Basic',
            'Last_Morning_Advance', 'Last_Morning_QC_Team', 'Last_Evening_Basic', 'Last_Evening_Advance', 'Last_Evening_QC_Team',
            'Last_Night_Basic', 'Last_Night_Advance', 'Last_Night_QC_Team', 'Weekly_Report', 'best_performer', 'bad_performer']));
    }

    public function attendence(Request $request){
        $user_id = Auth::user()->id;

        if($request->has('team'))
            $team = $request->input('team');
        else
            $team = "DHK";

        if ($user_id == 50)
            $team = "NAT";

        $rows = Performance::where('Loc', [$team])
            ->orderBy('date', 'desc')
            ->orderBy('Shift','asc')
            ->orderBy('Role','asc')
            ->orderBy('Efficiency','desc');

        $shift = "";
        if($request->has('shift')){
            if (!empty($request->input('shift'))) {
                $shift = $request->input('shift');
                $rows = $rows->where('Shift', [$shift]);
            }
        }

        $designer = "";
        if($request->has('designer')){
            if (!empty($request->input('designer'))){
                $designer = $request->input('designer');
                $rows=$rows->where('Name', [$designer]);
            }
        }

        $date = Carbon::today();
        if (!empty($request->input('date')))
            $date = date_create($request->input('date'));
        $date = $date->format('Y-m-d');

        if (!empty($request->input('date_to')))
            $date_to = date_create($request->input('date_to'));
        else
            $date_to = Carbon::today();
        $date_to = $date_to->format('Y-m-d');

        $rows = $rows->whereBetween('Date', [$date, $date_to])->paginate(100);
        return view("reader.page.attendence", compact(['rows', 'designer', 'shift', 'date', 'date_to', 'team']));
    }

    public function performance(Request $request)
    {
        $job=Performance::where('JobId', [$request->input('job_id')])
            ->first();

        $productivities=Log::where('JobId', [$request->input('job_id')])
            ->orderBy('Efficiency','asc')
            ->get();

        return view("reader.page.job", compact(['job', 'productivities']));
    }

    public function performances()
    {
        $rows=Performance::orderBy('date', 'desc')
            ->orderBy('Shift','asc')
            ->orderBy('Efficiency','desc')
            ->paginate(50);
        return view("reader.page.performances", compact("rows"));
    }

    public function jobs(Request $request)
    {
        $user_id = Auth::user()->id;

        if($request->has('team'))
            $team = $request->input('team');
        else
            $team = "DHK";

        if ($user_id == 50)
            $team = "NAT";

        $rows=NewJob::orderBy('SL', 'desc')
            ->where('Loc', [$team]);

        $designer = "";
        if($request->has('designer')){
            $designer = $request->input('designer');
            if (!empty($designer) & $designer != "All Designers"){
                $rows = $rows->where('Name', [$designer]);
            }
        }

        $job_id = "";
        if($request->has('job_id')){
            $job_id = $request->input('job_id');
            if (!empty($job_id) & $job_id != "All Jobs") {
                $rows = $rows->where('JobId', [$job_id]);
            }
        }

        $date_request = Carbon::today();
        if (!empty($request->input('date')))
            $date_request = date_create($request->input('date'));

        $date = $date_request->format('Y-m-d');

        $shift = "";
        $date_to = Carbon::today();
        $designers = Performance::orderBy('Name','asc')
            ->where('Date', '>', Carbon::now()->addDay(-33))
            ->where('Loc', [$team])
            ->distinct()->get(['Name']);

        $jobs = NewJob::orderBy('SL','desc')
            ->where('Date', '>', Carbon::now()->addDay(-11))
            ->distinct()->get(['JobId']);

        $rows=$rows->take(999)->paginate(100);
        return view("reader.page.jobs", compact(['rows', 'shift', 'designers', 'designer',
            'jobs', 'date', 'date_to', 'job_id', 'team']));
    }

    public function production_error(Request $request)
    {
        $user_id = Auth::user()->id;

        if($request->has('team'))
            $team = $request->input('team');
        else
            $team = "DHK";

        if ($user_id == 50)
            $team = "NAT";

        $rows=Feedback::orderBy('ReportTime', 'desc')
            ->where('Loc', [$team]);

        $designer = "";
        if($request->has('designer')){
            $designer = $request->input('designer');
            if (!empty($designer) & $designer != "All Designers"){
                $rows = $rows->where('Name', [$designer]);
            }
        }

        $job_id = "";
        if($request->has('job_id')){
            $job_id = $request->input('job_id');
            if (!empty($job_id) & $job_id != "All Jobs") {
                $rows = $rows->where('JobId', [$job_id]);
            }
        }

        $date_request = Carbon::today();
        if (!empty($request->input('date')))
            $date_request = date_create($request->input('date'));

        $date = $date_request->format('Y-m-d');

        $date_to = Carbon::today();
        $designers = Performance::orderBy('Name','asc')
            ->where('Date', '>', Carbon::now()->addDay(-33))
            ->where('Loc', [$team])
            ->distinct()->get(['Name']);

        $jobs = NewJob::orderBy('SL','desc')
            ->where('Date', '>', Carbon::now()->addDay(-11))
            ->distinct()->get(['JobId']);

        $rows=$rows->take(999)->paginate(100);
        return view("reader.page.production_error", compact(['rows', 'designers', 'designer',
            'jobs', 'date', 'date_to', 'job_id', 'team']));
    }

    public function pending_jobs(Request $request)
    {
        $user_id = Auth::user()->id;

        if($request->has('team'))
            $loc = $request->input('team');
        else
            $loc = "DHK";

        if ($user_id == 50)
            $loc = "NAT";

        $basic = RunningJob::join('new_jobs', 'new_jobs.JobId', '=', 'running_jobs.JobId')
            ->orderBy('new_jobs.delivery', 'asc')
            ->where('new_jobs.Loc', $loc)
            ->where('running_jobs.IsDone', 0)
            ->where('running_jobs.Team', 'Basic')
            ->get();

        // $basic = RunningJob::join('new_jobs', 'new_jobs.JobId', '=', 'running_jobs.JobId')
        //     ->orderBy('new_jobs.delivery', 'asc')
        //     ->where('new_jobs.Loc', $loc)
        //     ->where('running_jobs.IsDone', 0)
        //     ->where('running_jobs.Team', 'Basic')
        //     ->get();

        $advance = RunningJob::join('new_jobs', 'new_jobs.JobId', '=', 'running_jobs.JobId')
            ->orderBy('new_jobs.delivery', 'asc')
            ->where('new_jobs.Loc', $loc)
            ->where('running_jobs.IsDone', 0)
            ->where('running_jobs.Team', 'Advance')
            ->get();

        $QC_Team = RunningJob::join('new_jobs', 'new_jobs.JobId', '=', 'running_jobs.JobId')
            ->orderBy('new_jobs.delivery', 'asc')
            ->where('new_jobs.Loc', $loc)
            ->where('running_jobs.IsDone', 0)
            ->where('running_jobs.Team', 'QC_Team')
            ->get();

        $newJobs = NewJob::orderBy('delivery','asc')
            ->where('Status', 'New')
            ->where('Loc', $loc)
            ->get();

        return view("reader.page.pendingJobs", compact(['basic', 'advance', 'QC_Team', 'newJobs']));
    }

    public function designer(Request $request)
    {
        $name = "";
        if($request->has('name')){
            $name = $request->input('name');
        }

        $designer = Performance::orderBy('ID','desc');
        $designer = $designer->where('Name', $name);
        $rows = Log::orderBy('Efficiency','asc');
        $rows = $rows->where('Name', [$name]);

        $job_id = "";
        if($request->has('job_id')){
            $job_id = $request->input('job_id');
            if (!empty($job_id) & $job_id != "All Jobs"){
                $rows=$rows->where('JobId', [$job_id]);
            }
        }

        $date_request = Carbon::today();
        if (!empty($request->input('date')))
            $date_request = date_create($request->input('date'));

        $date = $date_request->format('Y-m-d');
        $designer = $designer->where('Date', $date)->first();

        $shift = "";
        if($request->has('shift')){
            $shift = $request->input('shift');
            if (!empty($shift) & $shift != "All Shift"){
                $Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.' 07:00:00');
                $Morning_End = date_create_from_format('Y-m-d H:i:s', $date.' 15:00:00')->format('Y-m-d H:i:s');
                $Evening_End = date_create_from_format('Y-m-d H:i:s', $date.' 23:00:00')->format('Y-m-d H:i:s');
                if ($shift == "Morning"){
                    $Morning_Start = $Start->format('Y-m-d H:i:s');
                    $rows = $rows->whereBetween('StartTime', [$Morning_Start, $Morning_End]);
                }
                elseif ($shift == "Evening"){
                    $rows = $rows->whereBetween('StartTime', [$Morning_End, $Evening_End]);
                }
                else{
                    $Night_End = $Start->addDay(1)->format('Y-m-d H:i:s');
                    $rows = $rows->whereBetween('StartTime', [$Evening_End, $Night_End]);
                }
            }
        }

        if (!empty($request->input('date_to')))
            $date_to = date_create($request->input('date_to'));
        else
            $date_to = Carbon::today();
        $date_to = $date_to->format('Y-m-d');

        $rows = $rows->whereBetween('Date', [$date, $date_to]);
        $designers = Performance::orderBy('Name','asc')
            ->where('Date', '>', Carbon::now()->addDay(-33))
            ->distinct()->get(['Name']);

        $jobs = NewJob::orderBy('SL','desc')
            ->where('Date', '>', Carbon::now()->addDay(-11))
            ->distinct()->get(['JobId']);

        $rows = $rows->get();
        return view("reader.page.designer", compact(['jobs', 'rows', 'shift', 'name', 'designer', 'designers',  'date', 'date_to', 'job_id']));
    }

    public function job(Request $request)
    {
        $job_id = "";
        if($request->has('job_id')){
            $job_id = $request->input('job_id');
        }

        $job = NewJob::where('JobId', $job_id)->first();

        $rows = Log::orderBy('Efficiency','asc');
        $rows = $rows->where('JobId', [$job_id]);

        $designer = "";
        if($request->has('designer')){
            $designer = $request->input('designer');
            if (!empty($designer) & $designer != "All Designers"){
                $rows=$rows->where('Name', [$designer]);
            }
        }

        $date_request = Carbon::today();
        if (!empty($request->input('date')))
            $date_request = date_create($request->input('date'));

        $date = $date_request->format('Y-m-d');

        $shift = "";
        if($request->has('shift')){
            $shift = $request->input('shift');
            if (!empty($shift) & $shift != "All Shift"){
                $Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.' 07:00:00');
                $Morning_End = date_create_from_format('Y-m-d H:i:s', $date.' 15:00:00')->format('Y-m-d H:i:s');
                $Evening_End = date_create_from_format('Y-m-d H:i:s', $date.' 23:00:00')->format('Y-m-d H:i:s');
                if ($shift == "Morning"){
                    $Morning_Start = $Start->format('Y-m-d H:i:s');
                    $rows = $rows->whereBetween('StartTime', [$Morning_Start, $Morning_End]);
                }
                elseif ($shift == "Evening"){
                    $rows = $rows->whereBetween('StartTime', [$Morning_End, $Evening_End]);
                }
                else{
                    $Night_End = $Start->addDay(1)->format('Y-m-d H:i:s');
                    $rows = $rows->whereBetween('StartTime', [$Evening_End, $Night_End]);
                }
            }
        }

        if (!empty($request->input('date_to')))
            $date_to = date_create($request->input('date_to'));
        else
            $date_to = Carbon::today();
        $date_to = $date_to->format('Y-m-d');

        $rows = $rows->whereBetween('Date', [$date, $date_to]);       
        $designers = Performance::orderBy('Name','asc')
            ->where('Date', '>', Carbon::now()->addDay(-33))
            ->distinct()->get(['Name']);

        $jobs = NewJob::orderBy('SL','desc')
            ->where('Date', '>', Carbon::now()->addDay(-11))
            ->distinct()->get(['JobId']);

        $rows = $rows->get();
        return view("reader.page.job", compact(['job', 'jobs', 'rows', 'shift', 'designer', 'designers',  'date', 'date_to', 'job_id']));
    }

    public function productivity(Request $request)
    {
        $user_id = Auth::user()->id;

        if($request->has('team'))
            $team = $request->input('team');
        else
            $team = "DHK";

        if ($user_id == 50)
            $team = "NAT";

        $rows=Log::where('Loc', [$team])
            ->orderBy('SL','desc');

        $designer = "";
        if($request->has('designer')){
            $designer = $request->input('designer');
            if (!empty($designer) & $designer != "All Designers"){
                $rows = $rows->where('Name', [$designer]);
            }
        }

        $job_id = "";
        if($request->has('job_id')){
            $job_id = $request->input('job_id');
            if (!empty($job_id) & $job_id != "All Jobs") {
                $rows = $rows->where('JobId', [$job_id]);
            }
        }

        $date = Carbon::today();
        if (!empty($request->input('date')))
            $date = date_create($request->input('date'));

        $shift = "";
        if($request->has('shift')){
            $shift = $request->input('shift');
            $date = $date->format('Y-m-d');           
        }else{
            if (empty($request->input('date'))){
                $date = $date->format('Y-m-d');
        
                $Morning_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'07:00:00');
                $Evening_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'15:00:00');
                $Night_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'23:00:00');
    
                if (Carbon::now() > $Morning_Start)
                    $shift = 'Morning';
        
                if (Carbon::now() > $Evening_Start)
                    $shift = 'Evening';
        
                if (Carbon::now() > $Night_Start)
                    $shift = 'Night';
            }
        }
        
        if (empty($request->input('date'))){
            if(Carbon::today()->format('A') == "AM" & $shift == "Night"){
                $date = Carbon::today()->addDay(-1)->format('Y-m-d');
            }
        }

        if ($shift != "All Shift"){
            $Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.' 07:00:00');
            $Morning_End = date_create_from_format('Y-m-d H:i:s', $date.' 15:00:00')->format('Y-m-d H:i:s');
            $Evening_End = date_create_from_format('Y-m-d H:i:s', $date.' 23:00:00')->format('Y-m-d H:i:s');

            if ($shift == "Morning"){
                $Morning_Start = $Start->format('Y-m-d H:i:s');
                $rows = $rows->whereBetween('StartTime', [$Morning_Start, $Morning_End]);
            }
            elseif ($shift == "Evening"){
                $rows = $rows->whereBetween('StartTime', [$Morning_End, $Evening_End]);
            }
            else{
                $Night_End = $Start->addDay(1)->format('Y-m-d H:i:s');
                $rows = $rows->whereBetween('StartTime', [$Evening_End, $Night_End]);
            }
        }

        if (!empty($request->input('date_to')))
            $date_to = date_create($request->input('date_to'));
        else
            $date_to = Carbon::today();

        $date_to = $date_to->format('Y-m-d');
        $rows = $rows->where('Service', 'NOT LIKE', "%QC%")->whereBetween('Date', [$date, $date_to]);
        $count = 0;
        $rows=$rows->take(9999)->get();

        $designers = Performance::orderBy('Name','asc')
            ->where('Date', '>', Carbon::now()->addDay(-33))
            ->where('Loc', [$team])
            ->distinct()->get(['Name']);

        $jobs = NewJob::orderBy('SL','desc')
            ->where('Date', '>', Carbon::now()->addDay(-11))
            ->distinct()->get(['JobId']);

        return view("reader.page.productivity", compact(['rows', 'shift', 'designers', 'designer',
            'jobs', 'date', 'date_to', 'job_id', 'team', 'count']));
    }

    public function qc_report(Request $request){
        $user_id = Auth::user()->id;

        if($request->has('team'))
            $team = $request->input('team');
        else
            $team = "DHK";

        if ($user_id == 50)
            $team = "NAT";

        $rows = Log::where('Loc', [$team])
            ->orderBy('SL','desc');

        $designer = "";
        if($request->has('designer')){
            $designer = $request->input('designer');
            if (!empty($designer) & $designer != "All Designers"){
                $rows=$rows->where('Name', [$designer]);
            }
        }

        $job_id = "";
        if($request->has('job_id')){
            $job_id = $request->input('job_id');
            if (!empty($job_id) & $job_id != "All Jobs") {
                $rows = $rows->where('JobId', [$job_id]);
            }
        }

        $date = Carbon::today();
        if (!empty($request->input('date')))
            $date = date_create($request->input('date'));

        $shift = "";
        if($request->has('shift')){
            $shift = $request->input('shift');
            $date = $date->format('Y-m-d');           
        }else{
            if (empty($request->input('date'))){
                $date = $date->format('Y-m-d');
        
                $Morning_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'07:00:00');
                $Evening_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'15:00:00');
                $Night_Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.'23:00:00');
    
                if (Carbon::now() > $Morning_Start)
                    $shift = 'Morning';
        
                if (Carbon::now() > $Evening_Start)
                    $shift = 'Evening';
        
                if (Carbon::now() > $Night_Start)
                    $shift = 'Night';
            }
        }
        
        if (empty($request->input('date'))){
            if(Carbon::today()->format('A') == "AM" & $shift == "Night"){
                $date = Carbon::today()->addDay(-1)->format('Y-m-d');
            }
        }

        if ($shift != "All Shift"){
            $Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.' 07:00:00');
            $Morning_End = date_create_from_format('Y-m-d H:i:s', $date.' 15:00:00')->format('Y-m-d H:i:s');
            $Evening_End = date_create_from_format('Y-m-d H:i:s', $date.' 23:00:00')->format('Y-m-d H:i:s');

            if ($shift == "Morning"){
                $Morning_Start = $Start->format('Y-m-d H:i:s');
                $rows = $rows->whereBetween('StartTime', [$Morning_Start, $Morning_End]);
            }
            elseif ($shift == "Evening"){
                $rows = $rows->whereBetween('StartTime', [$Morning_End, $Evening_End]);
            }
            else{
                $Night_End = $Start->addDay(1)->format('Y-m-d H:i:s');
                $rows = $rows->whereBetween('StartTime', [$Evening_End, $Night_End]);
            }
        }

        // $shift = "";
        // if($request->has('shift')){
        //     $shift = $request->input('shift');
        //     if (!empty($shift) & $shift != "All Shift"){
        //         $Start = Carbon::createFromFormat('Y-m-d H:i:s', $date.' 07:00:00');
        //         $Morning_End = date_create_from_format('Y-m-d H:i:s', $date.' 15:00:00')->format('Y-m-d H:i:s');
        //         $Evening_End = date_create_from_format('Y-m-d H:i:s', $date.' 23:00:00')->format('Y-m-d H:i:s');
        //         if ($shift == "Morning"){
        //             $Morning_Start = $Start->format('Y-m-d H:i:s');
        //             $rows = $rows->whereBetween('StartTime', [$Morning_Start, $Morning_End]);
        //         }
        //         elseif ($shift == "Evening"){
        //             $rows = $rows->whereBetween('StartTime', [$Morning_End, $Evening_End]);
        //         }
        //         else{
        //             $Night_End = $Start->addDay(1)->format('Y-m-d H:i:s');
        //             $rows = $rows->whereBetween('StartTime', [$Evening_End, $Night_End]);
        //         }
        //     }
        // }

        if (!empty($request->input('date_to')))
            $date_to = date_create($request->input('date_to'));
        else
            $date_to = Carbon::today();
        $date_to = $date_to->format('Y-m-d');

        $rows = $rows->where('Service', 'LIKE', "%QC%")->whereBetween('Date', [$date, $date_to]);
        $count = $rows->groupby('Image')->get()->count();

        $designers = Performance::whereIn('Role', ['QC', 'SI'])
            ->where('Date', '>', Carbon::now()->addDay(-33))
            ->where('Loc', [$team])
            ->orderBy('Name','asc')
            ->distinct()->get(['Name']);

        $jobs = NewJob::orderBy('SL','desc')
            ->where('Date', '>', Carbon::now()->addDay(-11))
            ->distinct()->get(['JobId']);

        $rows=$rows->take(999)->get();
        return view("reader.page.qc_report", compact(['rows', 'shift', 'designers',
            'designer', 'jobs', 'date', 'date_to', 'job_id', 'team', 'count']));
    }

    public function activities()
    {

    }

    public function revenue()
    {

    }
}
