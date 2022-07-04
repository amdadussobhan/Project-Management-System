@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Workloads </h3>
@endsection
<?php
    $role = Auth::User()->role;
    $users = App\User::Where('role', 'admin')->orWhere('role', 'writer')->get();
?>
@section('content')
    <div class="container-fluid">
        <strong>
            <div class="row align-items-center">
                <div class="col mb-2 bg-light">
                    @include('reader.menu.filter_workloads')
                </div>
            </div>
        </strong>

        <div class="row align-items-center">
            <div class="col mb-2">
                @include('reader.menu.left_menu')
            </div>

            <div class="col mb-2">
                @include('reader.menu.right_menu')
            </div>
        </div>

        <?php $isBlank = true; ?>

        @if($Basic->count() != 0)
            <h3 align="center"> Basic Team Workload</h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                    <th>SL</th>
                    <th>Job ID</th>
                    <th>Folder</th>
                    <th>Category</th>
                    <th>Service</th>
                    <th>Incoming</th>
                    <th>Delivery</th>
                    <th>Job Time</th>
                    <th>Input File</th>
                    <th>WorkLoad</th>
                </thead>
                <?php
                    $SL = 1;
                    $TotalInput = 0;
                    $TotalWorkload = 0;
                ?>
                @foreach($Basic as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</a></td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>
                        <td>{{$row->Service}}</td>

                        @if($row->Incoming != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Incoming)) }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($row->Delivery != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{ $row->Target_Time }}</td>
                        <td>{{ $row->Input_File }}</td>
                        <td>{{ Round($row->Total_Load,1) }}</td>

                        <?php
                            $TotalInput += $row->Input_File;
                            $TotalWorkload += $row->Total_Load;
                        ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="8" align="right"> <b> Total ---> </b> </td>
                    <td><b> {{ $TotalInput }} </b></td>
                    <td><b> {{ Round($TotalWorkload) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        @if($Advance->count() != 0)
            <h3 align="center"> Advance Team Workload </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                    <th>SL</th>
                    <th>Job ID</th>
                    <th>Folder</th>
                    <th>Category</th>
                    <th>Service</th>
                    <th>Incoming</th>
                    <th>Delivery</th>
                    <th>Job Time</th>
                    <th>Input File</th>
                    <th>WorkLoad</th>
                </thead>
                <?php
                $SL = 1;
                    $TotalInput = 0;
                    $TotalWorkload = 0;
                ?>
                @foreach($Advance as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</a></td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>
                        <td>{{$row->Service}}</td>

                        @if($row->Incoming != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Incoming)) }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($row->Delivery != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{ $row->Target_Time }}</td>
                        <td>{{ $row->Input_File }}</td>
                        <td>{{ Round($row->Total_Load,1) }}</td>

                        <?php
                            $TotalInput += $row->Input_File;
                            $TotalWorkload += $row->Total_Load;
                        ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="8" align="right"> <b> Total ---> </b> </td>
                    <td><b> {{ $TotalInput }} </b></td>
                    <td><b> {{ Round($TotalWorkload) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        @if($QC_Team->count() != 0)
            <h3 align="center"> QC Team Workload </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                    <th>SL</th>
                    <th>Job ID</th>
                    <th>Folder</th>
                    <th>Category</th>
                    <th>Service</th>
                    <th>Incoming</th>
                    <th>Delivery</th>
                    <th>Input File</th>
                    <th>Job Time</th>
                    <th>WorkLoad</th>
                </thead>
                <?php
                    $SL = 1;
                    $TotalInput = 0;
                    $TotalWorkload = 0;
                ?>
                @foreach($QC_Team as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</a></td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>
                        <td>{{$row->Service}}</td>

                        @if($row->Incoming != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Incoming)) }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($row->Delivery != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{ $row->Target_Time }}</td>
                        <td>{{ $row->Input_File }}</td>
                        <td>{{ Round($row->Total_Load,1) }}</td>

                        <?php
                            $TotalInput += $row->Input_File;
                            $TotalWorkload += $row->Total_Load;
                        ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="8" align="right"> <b> Total ---> </b> </td>
                    <td><b> {{ $TotalInput }} </b></td>
                    <td><b> {{ Round($TotalWorkload) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        @if($New_Job->count() != 0)
            <h3 align="center"> New Jobs Received (UnTouch) </h3>
            <table class="table table-bordered table-striped text-center table-sm">
                <thead>
                    <th>SL</th>
                    <th>Job ID</th>
                    <th>Folder</th>
                    <th>Category</th>
                    <th>Incoming</th>
                    <th>Delivery</th>
                    <th>Job Time</th>
                    <th>Input File</th>
                    <th>WorkLoad</th>
                </thead>
                <?php
                    $SL = 1;
                    $TotalInput = 0;
                    $TotalWorkload = 0;
                ?>
                @foreach($New_Job as $row)
                    <tr>
                        <td>{{$SL++}}</td>

                        <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</a></td>
                        <td>{{$row->Folder}}</td>
                        <td>{{$row->Category}}</td>

                        @if($row->Incoming != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Incoming)) }}</td>
                        @else
                            <td></td>
                        @endif

                        @if($row->Delivery != null)
                            <td>{{ date('d-M-Y h:i A', strtotime($row->Delivery)) }}</td>
                        @else
                            <td></td>
                        @endif

                        <td>{{ $row->Target_Time }}</td>
                        <td>{{ $row->Input_File }}</td>
                        <td>{{ Round($row->Total_Load,1) }}</td>

                        <?php
                            $TotalInput += $row->Input_File;
                            $TotalWorkload += $row->Total_Load;
                        ?>
                    </tr>
                @endforeach
                <tr>
                    <td colspan="7" align="right"> <b> Total ---> </b> </td>
                    <td><b> {{ $TotalInput }} </b></td>
                    <td><b> {{ Round($TotalWorkload) }} </b></td>
                </tr>
            </table>
            <?php $isBlank = false; ?>
        @endif

        <br><br><br><br><br>

        @if($isBlank)
            <h3 align="center">There have no workloads on selected date.</h3>
        @endif

        <br><br><br><br><br>
    </div>
@endsection
