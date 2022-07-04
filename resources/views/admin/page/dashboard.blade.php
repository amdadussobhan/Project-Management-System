@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Dashboard</h3>
@endsection
<?php $role = Auth::User()->role; ?>

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
        <br><br><br><br><br><br>
        <center>
            <h1>Dashboard will apear here soon</h1>
            <h2 class="text-success">This page is under construction</h2>
            <a href="{{ URL::previous() }}" class="btn btn-secondary">Go Back</a>
        </center>
    </div>
@endsection
