<?php
    use Illuminate\Support\Facades\Auth;
    $role = Auth::User()->role; 
?>

<!doctype html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>{{ config('app.name', 'Laravel') }}</title>
        <script src="{{ asset('js/app.js') }}" defer></script>
        <link href="{{ asset('css/app.css') }}" rel="stylesheet">
        <link href="{{ asset('css/bootstrap.min.css') }}" rel="stylesheet">
        <link href="{{ asset('css/all.min.css') }}" rel="stylesheet">
        <link href="{{ asset('css/style.css') }}" rel="stylesheet">
    </head>
    <body>
        <div class="container mt-5">
            <div class="text-center">
                <h1 class="mr-5 mt-4 ml-5">Work Order Summary</h1>
            </div>

            <div class="row mr-0 ml-3 mb-3 mt-3">
                <div class="col-2">
                    <h5>Client Code : <br></h5>
                    <h5>Client Name : <br></h5>
                    <h5>Address : <br></h5>
                    <h5>Ref ID : <br></h5>
                </div>

                <div class="col-7 m-0 p-0 float-left">
                    <h5>{{ $workorder->skill_code }} <br></h5>
                    <h5>{{ $workorder->name }} <br></h5>
                    <h5>{{ $workorder->address }} <br></h5>
                    <h5>{{ $workorder->ref_id }} <br></h5>
                </div>
            </div>       

            <table class="table table-bordered table-striped text-center table-sm">
                <thead>                
                    <th style="vertical-align:middle;">SL</th>
                    <th style="vertical-align:middle;">Job ID</th>
                    <th style="vertical-align:middle;">Folder Name</th>
                    <th style="vertical-align:middle;">Service</th>
                    <th style="vertical-align:middle;">Date</th>
                    <th style="vertical-align:middle;">Qnt</th>
                </thead>

                <?php $SL = 1; ?>
                @if($rows != null)
                    @foreach($rows as $row)
                        <tr>
                            <td>{{$SL++}}</td>
                            <td>{{$row->JobId}}</td>
                            <td>{{$row->Folder}}</td>
                            <td>{{$row->Service}}</td>

                            @if($row->Delivery != null)
                                <td>{{ date('d-M-Y', strtotime($row->Delivery)) }}</td>
                            @else
                                <td></td>
                            @endif

                            <td>{{$row->OutputAmount}}</td>
                        </tr>
                    @endforeach
                    <tr>
                        <td colspan="5" align="right"> <b>Grant Total File Quantity : </b> </td>
                        <td><b> {{ $TotalQnt }} </b></td>
                    </tr>
                @endif
            </table>         
            <br><br><br><br>
        </div>

        <!-- Scripts-->
        <script src="{{ asset('js/jQuery_3.5.1.js') }}" defer></script>
        <script src="{{ asset('js/bootstrap.min.js') }}" defer></script>
        <script src="{{ asset('js/all.min.js') }}" defer></script>
        <script src="{{ asset('js/function.js') }}" defer></script>
        <script src="{{ asset('js/app.js') }}" defer></script>
        <script>
            window.onload = function () {
                window.print();
            }
        </script>
    </body>
</html>
