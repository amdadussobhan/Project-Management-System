@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Test Report</h3>
@endsection

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
    </div>
    <div class="container-fluid">
        <table class="table table-hover table-bordered table-striped text-center table-sm">
            <thead>
                <th>SL</th>
                <th>Job ID</th>
                <th>Image</th>
                <th>Service</th>
                <th>Start Time</th>
                <th>End Time</th>
                <th>Target Time</th>
                <th>Pro Time</th>
                <th>Efficiency</th>
            </thead>
            <?php $SL = 0; ?>
            @foreach($rows as $row)
                @if($row->Efficiency != null)
                    @if($row->Efficiency > 400)
                        <tr>
                    @elseif($row->Efficiency >= 100)
                        <tr style="background: #8cd985">
                    @elseif($row->Efficiency >= 90)
                        <tr style="background: #fff8b3">
                    @else
                        <tr style="background: #f1b0b7">
                    @endif
                @else
                    <tr>
                @endif
                    <td>{{++$SL}}</td>
                    <td><a href="/3/job?job_id={{ $row->JobId }}&date={{ $row->Date }}" target="_blank">{{$row->JobId}}</a></td>
                    <td>{{$row->Image}}</td>
                    <td>{{$row->Service}}</td>
                    <td>{{ date('d-M-Y h:i:s A', strtotime($row->StartTime)) }}</td>
                    <td>{{ date('d-M-Y h:i:s A', strtotime($row->EndTime)) }}</td>
                    <td>{{$row->TargetTime}}</td>
                    <td>{{$row->ProTime}}</td>
                    <td>{{$row->Efficiency}}%</td>
                    </tr>
            @endforeach
        </table>
        <br><br><br><br><br><br><br><br>
    </div>
@endsection
