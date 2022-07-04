@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Job Details</h3>
@endsection
<?php
    $user = Auth::User()->id;
    $role = Auth::User()->role;
?>

@section('content')
    <div class="container">
        <div class="row align-items-center">
            <div class="col mb-2">
                @include('reader.menu.left_menu')
            </div>

            <div class="col mb-2">
                @include('reader.menu.right_menu')
            </div>
        </div>
        <hr>
        <div class="row">
            <div class="col-md-6">
                <table class="table table-bordered table-striped text-center table-sm">
                    <tr>
                        <td><h5 class="d-inline"><strong>Job ID : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job != null)
                                    {{$job->JobId}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Category : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job != null)
                                    {{$job->Category}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Service : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job != null)
                                    {{$job->Service}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Amount : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job != null)
                                    {{$job->InputAmount}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Actual Time : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job != null)
                                    {{$job->ActualTime}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                </table>

            </div>

            <div class="col-md-6">
                <table class="table table-bordered table-striped text-center table-sm">
                    <tr>
                        <td><h5 class="d-inline"><strong>Incoming : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job->Incoming != null)
                                    {{ date('d-M-Y h:i A', strtotime($job->Incoming)) }}
                                @endif
                            </h6>
                        </td>
                    </tr>
                    <tr>
                        <td><h5 class="d-inline"><strong>Delivery : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job->Delivery != null)
                                    {{ date('d-M-Y h:i A', strtotime($job->Delivery)) }}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Type : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job != null)
                                    {{$job->Type}}
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Price : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job != null)
                                    @if($job->Currency == 'USD')
                                        ${{$job->Price}}
                                    @elseif($job->Currency == 'EURO')
                                        €{{$job->Price}}
                                    @elseif($job->Currency == 'TK')
                                        ৳{{$job->Price}}
                                    @else
                                        {{$job->Price}}
                                    @endif
                                @endif
                            </h6>
                        </td>
                    </tr>

                    <tr>
                        <td><h5 class="d-inline"><strong>Target Time : </strong></h5></td>
                        <td>
                            <h6 class="d-inline">
                                @if($job != null)
                                    {{$job->TargetTime}}
                                @endif
                            </h6>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="row">
            <div class="col text-center mb-2">
                <h5 class="d-inline">All Production Report are shown below </h5>
            </div>
        </div>

    </div>
    <div class="container-fluid">
        <table class="table table-hover table-bordered table-striped text-center table-sm">
            <thead>
            <th>SL</th>
            <th>Name</th>
            <th>Job ID</th>
            <th>Service</th>
            <th>Image</th>
            <th>Start Time</th>
            <th>End Time</th>
            <th>Target Time</th>
            <th>Pro File</th>
            <th>Efficiency</th>
            <th>Status</th>
            </thead> <?php $SL = 1; ?>
            @foreach($productivities as $productivity)
                @if($productivity->Efficiency != null)
                    @if($productivity->Efficiency >= 100)
                        <tr style="background: #8cd985">
                    @elseif($productivity->Efficiency >= 90)
                        <tr style="background: #fff8b3">
                    @else
                        <tr style="background: #f1b0b7">
                    @endif
                @else
                    <tr>
                @endif
                    <td>{{$SL++}}</td>
                    <td>{{$productivity->Name}}</td>
                    <td>{{$productivity->JobId}}</td>
                    <td>{{$productivity->Service}}</td>
                    <td>{{$productivity->Image}}</td>
                    <td>{{ date('d-M-Y h:i A', strtotime($productivity->StartTime)) }}</td>
                    <td>{{ date('d-M-Y h:i A', strtotime($productivity->EndTime)) }}</td>
                    <td>{{$productivity->TargetTime}}</td>
                    <td>{{$productivity->ProTime}}</td>
                    <td>{{$productivity->Efficiency}}%</td>
                    <td>{{$productivity->Status}}</td>
                    </tr>
            @endforeach
        </table>
        <br><br><br><br><br><br><br><br>
    </div>
@endsection
