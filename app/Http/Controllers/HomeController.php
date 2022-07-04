<?php

namespace App\Http\Controllers;

use App\Lead;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class HomeController extends Controller
{
    public function __construct()
    {
        $this->middleware('auth');
    }

    public function index()
    {
        if (Auth::guest())
            return view('auth.login');
        elseif (Auth::user()->role == "admin"){
            return redirect('/1/my_followup');
        }
        elseif (Auth::user()->role == "writer"){
            return redirect('/2/dashboard');
        }
        elseif (Auth::user()->role == "reader"){
            return redirect('3/dashboard');
        }
        elseif (Auth::user()->role == "accounts"){
            return redirect('4/dashboard');
        }
        else
            return view('page.home');
    }
}
