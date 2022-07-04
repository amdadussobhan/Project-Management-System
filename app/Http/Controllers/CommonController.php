<?php

namespace App\Http\Controllers;

use Carbon\Carbon;
use Illuminate\Http\Request;

class CommonController extends Controller
{
    public function todays_count($Query){
        $Query_Result = $Query->whereDate('created_at', Carbon::today());
        return $Query_Result;
    }

    public function weekly_count($Query){
        $weekStartDate = now()->startOfWeek()->format('Y-m-d');
        $weekEndDate = now()->endOfWeek()->format('Y-m-d');

        $Query_Result = $Query->whereBetween('created_at', [$weekStartDate, $weekEndDate]);
        return $Query_Result;
    }

    public function monthly_count($Query){
        $monthStartDate = now()->firstOfMonth()->format('Y-m-d');
        $monthEndDate = now()->endOfMonth()->format('Y-m-d');

        $Query_Result = $Query->whereBetween('created_at', [$monthStartDate, $monthEndDate]);
        return $Query_Result;
    }

    public function count_rounding($Query_Result){
        $Query_Count = count($Query_Result->get());
        if ($Query_Count < 10)
            $Query_Count = '00' . $Query_Count;
        elseif ($Query_Count < 100)
            $Query_Count = '0' . $Query_Count;

        return $Query_Count;
    }
}
