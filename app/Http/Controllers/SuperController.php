<?php

namespace App\Http\Controllers;

use App\Exports\ExportLeads;
use App\Exports\LeadsExport;
use App\Exports\RemarksExport;
use App\Imports\ImportLeads;
use App\Imports\LeadsImport;
use App\Imports\RemarkImport;
use Illuminate\Http\Request;
use Excel;

class SuperController extends Controller
{
    public function dashboard()
    {
        return view('super_admin.dashboard');
    }

    public function leads_export()
    {
        return Excel::download(new LeadsExport(), 'Leads.xlsx');
    }

    public function leads_import()
    {
        Excel::import(new LeadsImport(), request()->file('file'));
        return back()->with('success', 'Leads Imported Successfully');;
    }

    public function remarks_export()
    {
        return Excel::download(new RemarksExport(), 'Remarks.xlsx');
    }

    public function remarks_import()
    {
        Excel::import(new RemarkImport(), request()->file('file'));
        return back()->with('success', 'Remarks Imported Successfully');;
    }
}
