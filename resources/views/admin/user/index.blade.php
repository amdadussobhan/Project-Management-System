@extends('layouts.app')
@section('Head')
    <h3 class="text-white">ALL Accounts</h3>
@endsection

@section('content')
    <div class="container">
        <div class="row align-items-center">
            <div class="col-md-6 mb-2">
                @include('menu.left_menu')
            </div>
            <div class="col-md-6 mb-2">
                @include('menu.right_menu')
            </div>
        </div>
        <hr>
        <table class="table table-bordered table-hover text-center">
            <thead>
            <th>SL</th>
            <th>Name</th>
            <th>Phone</th>
            <th>Email</th>
            </thead>
            <?php $SL = 1 ?>
            @foreach($users as $user)
                <tr>
                    <td>{{$SL++}}</td>
                    <td><a href="/leads/{{$user->id}}">{{$user->name}}</a></td>
                    <td>{{$user->phone}}</td>
                    <td>{{$user->email}}</td>
                </tr>
            @endforeach
        </table>
        <a href="{{ URL::previous() }}" class="btn btn-secondary">Go Back</a>

        <!-- Create New user -->
        <button type="button" class="btn btn-success float-right" data-toggle="modal" data-target="#account">Create New</button>
        <div class="modal fade show" id="account">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Creating New account</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    {!! Form::open(['action'=>'UserController@store']) !!}
                    <div class="modal-body">
                        <center>
                            <h2>New user creation page will apear here soon</h2>
                            <h2 class="text-success">This process is under construction</h2>
                        </center>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <button type="submit" class="btn btn-success">Save</button>
                    </div>
                    {!! Form::close() !!}
                </div>
            </div>
        </div>
    </div>
@endsection
