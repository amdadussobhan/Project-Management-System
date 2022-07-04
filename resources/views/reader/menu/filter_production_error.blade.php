<form class="form-inline justify-content-center" action="{{ route('reader_production_error') }}" method="GET">

    <label class="px-2">Team : </label>
    <select class="form-control" style="width: 100px" name="team">
        <option value="{{  $team }}">
            @if( $team == "DHK")
                Dhaka
            @else
                Natore
            @endif
        </option>

        @if( $team != "DHK")
            <option value="DHK"> Dhaka </option>
        @endif

        @if( $team != "NAT")
            <option value="NAT"> Natore </option>
        @endif
    </select>

    <label class="px-2">Designers : </label>
    <select class="form-control" style="width: 140px" name="designer">
        <option value="{{ $designer }}">{{ $designer }}</option>
        <option value="All Designers"> All Designers </option>
        @foreach($designers as $designer)
            <option value= {{$designer->Name}} > {{$designer->Name}} </option>
        @endforeach
    </select>

    <label class="px-2">Job ID : </label>
    <select class="form-control" style="width: 160px" name="job_id">
        <option value="{{ $job_id }}">{{ $job_id }}</option>
        <option value="All Jobs"> All Jobs </option>
        @foreach($jobs as $job)
            <option value= {{$job->JobId}} > {{$job->JobId}} </option>
        @endforeach
    </select>

    <label class="px-2">From :</label>
    <input type="date" style="width: 170px" name="date" value="{{ $date }}" class="form-control">

    <label class="px-2">To :</label>
    <input type="date" style="width: 170px" name="date_to" value="{{ $date_to }}" class="form-control">

    <button class="btn btn-outline-primary" type="submit">Apply Filter</button>
</form>
