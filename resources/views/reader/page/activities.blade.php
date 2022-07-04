@extends('layouts.app')
@section('Head')
    <h3 class="text-white">ALL Follow Up</h3>
@endsection
<?php 
    $role = Auth::User()->role; 
    $categories = App\Category::all();
    $countries = App\Country::all();
?>
@section('content')
    <div class="container-fluid">
        <div class="row align-items-center">
            <div class="col mb-2">
                @include('menu.left_menu')
            </div>
            <div class="col mb-2">
                @include('menu.right_menu')
            </div>
        </div>
        <table class="table table-bordered table-striped text-center ">
            <thead class="table-info">
                <th>SL</th>
                <th>User Name</th>
                <th>Today's Leads</th>
                <th>Today's Followup</th>
                <th>Weekly Leads</th>
                <th>Weekly Followup</th>
                <th>Monthly Leads</th>
                <th>Monthly Followup</th>
            </thead>
            <?php $SL = 1 ?>
            @foreach($reports as $report)
                <tr>
                    <td>{{$SL++}}</td>
                    <td>Rajin</td>
                    <td>22</td>
                    <td>11</td>
                    <td>44</td>
                    <td>33</td>
                    <td>99</td>
                    <td>77</td>
                </tr>
                <tr>
                    <td>{{$SL++}}</td>
                    <td>AMDAD</td>
                    <td>22</td>
                    <td>11</td>
                    <td>44</td>
                    <td>33</td>
                    <td>99</td>
                    <td>77</td>
                </tr>
                <tr>
                    <td>{{$SL++}}</td>
                    <td>X</td>
                    <td>22</td>
                    <td>11</td>
                    <td>44</td>
                    <td>33</td>
                    <td>99</td>
                    <td>77</td>
                </tr>
                <tr>
                    <td>{{$SL++}}</td>
                    <td>Y</td>
                    <td>22</td>
                    <td>11</td>
                    <td>44</td>
                    <td>33</td>
                    <td>99</td>
                    <td>77</td>
                </tr>
                <tr>
                    <td>{{$SL++}}</td>
                    <td>Z</td>
                    <td>22</td>
                    <td>11</td>
                    <td>44</td>
                    <td>33</td>
                    <td>99</td>
                    <td>77</td>
                </tr>
            @endforeach
        </table>

        <!-- Create Follow Up Model-->
        @include('leads.create_lead_modal')
        @include('page.count')

    </div>
@endsection
