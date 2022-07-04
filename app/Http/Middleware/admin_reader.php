<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Support\Facades\Auth;

class admin_reader
{
    public function handle($request, Closure $next)
    {
        $role = Auth::user()->role;
        if ($role == 'admin' or $role == 'reader')
            return $next($request);
        else
            return redirect()->back();
    }
}
