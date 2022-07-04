@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Jobs List </h3>
@endsection

@section('content')
    <div class="container-fluid">
        <strong>
            <div class="row align-items-center">
                <div class="col mb-2 bg-light">
                    @include('reader.menu.filter_jobs')
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

        <table class="table table-bordered table-striped text-center table-sm">
            <thead>
                <th style="vertical-align:middle;">SL</th>
                <th style="vertical-align:middle;">Job ID</th>
                <th style="width: 20%; vertical-align:middle;">Folder</th>
                <th style="vertical-align:middle;">Category</th>
                <th style="vertical-align:middle;">Incoming</th>
                <th style="vertical-align:middle;">Delivery</th>
                <th style="vertical-align:middle;">Service</th>
                <th style="vertical-align:middle;">Amount</th>
                <th style="vertical-align:middle;">Actual Time</th>
                <th style="vertical-align:middle;">Target Time</th>
                <th style="vertical-align:middle;">Pro Time</th>
                <th style="vertical-align:middle;">Status</th>
                <th style="vertical-align:middle;">Receiver</th>
            </thead>
            <?php $SL = 1; ?>
            @foreach($rows as $row)
                @if($row->ProTime <= $row->ActualTime)
                    <tr style="background: #8cd985">
                @else
                    <tr style="background: #f1b0b7">
                @endif
                    <td>{{$SL++}}</td>

                    <td><a href="/3/job?job_id={{$row->JobId}}">{{$row->JobId}}</td>
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

                    <td>{{$row->Service}}</td>
                    <td>{{$row->InputAmount}}</td>
                    <td>{{$row->ActualTime}}</td>
                    <td>{{ Round($row->TargetTime,1) }}</td>
                    <td>{{ Round($row->ProTime,1) }}</td>
                    <td>{{$row->Status}}</td>
                    <td>{{$row->Receiver}}</td>
                </tr>
            @endforeach
        </table>
        <div class="row justify-content-center"> {{$rows->links()}}</div>
        <br><br><br><br><br>
    </div>
@endsection
