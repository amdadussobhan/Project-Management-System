@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">.</div>

                <div class="card-body">
                    @if (session('status'))
                        <div class="alert alert-success" role="alert">
                            {{ session('status') }}
                        </div>
                    @endif
                    <center><br>
                        <h1 class="text-primary"> Welcome to Skill PMS. </h1> <br>
                        <h3 class="text-success"> You are Successfully Login. </h3> <br>
                        <h4 class="text-warning"> Currently you haven't any access, inform to your admin to get your access. </h4>
                    </center>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection
