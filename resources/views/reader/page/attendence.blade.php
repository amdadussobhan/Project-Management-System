@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Showing attendence </h3>
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
                    @include('reader.menu.filter_attendence')
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
                <th>Name</th>
                <th>Team</th>
                <th>Shift</th>
                <th>Login</th>
                <th>Logout</th>
                <th>Work Time</th>
                <th>File</th>
                <th>Job Time</th>
                <th>Pro Time</th>
                <th>Efficiency</th>
                <th>Quality</th>
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
                    <td><a href="/leads/{{$row->id}}">{{$row->Name}}</a></td>

                    @if($row->Role == '')
                        <td>Production</td>
                    @else
                        <td>{{$row->Role}}_Team</td>
                    @endif

                    @if($row->Shift != null)
                        <td>{{$row->Shift}}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->Login != null)
                        <td>{{ date('d-M-Y h:i A', strtotime($row->Login)) }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->Logout != null)
                        <td>{{ date('d-M-Y h:i A', strtotime($row->Logout)) }}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->WorkingTime != null)
                        <td>{{$row->WorkingTime}}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->File != null)
                        <td>{{$row->File}}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->JobTime != null)
                        <td>{{$row->JobTime}}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->ProTime != null)
                        <td>{{$row->ProTime}}</td>
                    @else
                        <td></td>
                    @endif

                    @if($row->Efficiency != null)
                        <td>{{$row->Efficiency}}%</td>
                    @else
                        <td></td>
                    @endif
                    @if($row->Quality != null)
                        <td>{{$row->Quality}}%</td>
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
