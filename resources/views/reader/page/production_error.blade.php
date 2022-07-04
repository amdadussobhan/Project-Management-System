@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Jobs List </h3>
@endsection

@section('content')
    <div class="container-fluid">
        <strong>
            <div class="row align-items-center">
                <div class="col mb-2 bg-light">
                    @include('reader.menu.filter_production_error')
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
                <th style="vertical-align:middle;">Name</th>
                <th style="vertical-align:middle;">Job_ID</th>
                <th style="width: 25%; vertical-align:middle;">Folder</th>
                <th style="width: 15%; vertical-align:middle;">Image</th>
                <th style="width: 25%; vertical-align:middle;">Error_Details</th>
                <th style="vertical-align:middle;">Report_Time</th>
                <th style="vertical-align:middle;">Reporter</th>
            </thead>
            <?php $SL = 1; ?>
            @foreach($rows as $row)
                <tr>
                    <td>{{$SL++}}</td>
                    <td>{{$row->Name}}</td>
                    <td>{{$row->JobID}}</td>
                    <td>{{$row->Folder}}</td>
                    <td>{{$row->Image}}</td>
                    <td>{{$row->Remarks}}</td>

                    @if($row->ReportTime != null)
                        <td>{{ date('d-M-Y h:i A', strtotime($row->ReportTime)) }}</td>
                    @else
                        <td></td>
                    @endif
                    
                    <td>{{$row->Reporter}}</td>
                </tr>
            @endforeach
        </table>
        <div class="row justify-content-center"> {{$rows->links()}}</div>
        <br><br><br><br><br>
    </div>
@endsection
