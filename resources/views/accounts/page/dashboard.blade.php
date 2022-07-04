@extends('layouts.app')
@section('Head')
    <h3 class="text-white">Accounts Dashboard</h3>
@endsection

@section('content')
    <div class="container">
        @include('accounts.menu.main_menu')

        <div class="row mt-2 mb-3">
            <div class="col-1"></div>
            <div class="col-3 bg-white shadow-lg rounded-lg">
                <br>
                <center>
                    <h3>000</h3>
                    <h4>Total Revenue</h4>
                </center>
                <br>
            </div>
            <div class="col-3 bg-white shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    <h3>000</h3>
                    <h4>Total Paid</h4>
                </center>
                <br>
            </div>
            <div class="col-3 shadow-lg rounded-lg ml-5">
                <br>
                <center>
                    <h3>000</h3>
                    <h4>Total Due</h4>
                </center>
                <br>
            </div>
        </div>        
    </div>
    <div class="container-fluid">
        <br><br><br><br><br>
    </div>
@endsection
