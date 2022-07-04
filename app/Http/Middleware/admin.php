<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Support\Facades\Auth;

class admin
{
    public function handle($request, Closure $next)
    {
        $user = Auth::user();
        if ($user->role == 'admin')
            return $next($request);
        else
            return redirect()->back();
    }
}
