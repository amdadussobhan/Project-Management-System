<?php

namespace App\Http\Controllers;

use App\Category;
use App\Favorite;
use App\Filter;
use App\Lead;
use App\Possibility;
use App\Remark;
use App\Status;
use Carbon\Carbon;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class AdminController extends Controller
{
    public function dashboard(){
        return view('admin.page.dashboard');
    }

    public function settings(){
        return view('admin.page.settings');
    }
}
