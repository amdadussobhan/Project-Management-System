<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Support\Facades\Auth;

class accounts
{
    public function handle($request, Closure $next)
    {
        $user = Auth::user();
        if ($user->role == 'accounts')
            return $next($request);
        else
            return redirect()->back();
    }
}
