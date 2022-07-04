@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing Shift Report </h3>
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
                    @include('reader.menu.filter_shift_report')
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
                <th>SL</th>
                <th>Date</th>
                <th>Shift</th>
                <th>Capacity</th>
                <th>Workload</th>
                <th>Achieve</th>
                <th>Handload</th>
                <th>Input File</th>
                <th>Output File</th>
                <th>Efficiency</th>
                <th>Last 24 Input File</th>
                <th>Last 24 Output File</th>
            </thead>
            <?php $SL = 1 ?>
            @foreach($rows as $row)
                @if($row->Efficiency != null)
                    @if($row->Efficiency >= 100)
                        <tr style="background: #8cd985">
                    @elseif($row->Efficiency >= 90)
                        <tr style="background: #fff8b3">
                    @else
                        <tr style="background: #f1b0b7">
                    @endif
                @else
                    <tr style="background: #f1b0b7">
                @endif
                    <td>{{$SL++}}</td>

                    @if($row->Date != null)
                        <td>{{ date('d-M-Y', strtotime($row->Date)) }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->Shift != null)
                        <td><a href="/3/workloads?shift={{$row->Shift}}&date={{ date('d-m-Y', strtotime($row->Date)) }}" target="_blank">{{$row->Shift}}</a></td>
                    @else
                        <td></td>
                    @endif

                    @if($row->Capacity != null)
                        <td>{{$row->Capacity}}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->TotalLoad != null)
                        <td>{{ Round($row->TotalLoad) }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->AchieveLoad != null)
                        <td>{{ Round($row->AchieveLoad) }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->HandLoad != null)
                        <td>{{ Round($row->HandLoad) }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->TotalFile != null)
                        <td>{{ $row->TotalFile }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->ProDone != null)
                        <td>{{ $row->ProDone }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->Efficiency != null)
                        <td>{{ $row->Efficiency }}%</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->Last24Input != null)
                        <td>{{ $row->Last24Input }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->Last24Output != null)
                        <td>{{$row->Last24Output}}</td>
                    @else
                        <td></td>
                    @endif
                </tr>
            @endforeach
        </table>
        <div class="row justify-content-center"> {{$rows->links()}}</div>

{{--        @include('reader.page.count')--}}
        <br><br><br><br><br>
    </div>
@endsection
