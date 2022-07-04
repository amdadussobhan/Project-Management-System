<form class="form-inline justify-content-center" action="{{ route('reader_job') }}" method="GET">

    <label class="px-2">Shift : </label>
    <select class="form-control" style="width: 160px" name="shift">
        <option value="{{ $shift }}">{{ $shift }}</option>
        <option value="All Shift"> All Shift </option>
        <option value="Morning"> Morning </option>
        <option value="Evening"> Evening </option>
        <option value="Night"> Night </option>
    </select>

    <label class="px-2">Designer : </label>
    <select class="form-control" style="width: 160px" name="designer">
        <option value="{{ $designer }}">{{ $designer }}</option>
        <option value="All Designers"> All Designers </option>
        @foreach($designers as $designer)
            <option value= {{$designer->Name}} > {{$designer->Name}} </option>
        @endforeach
    </select>

    <label class="px-2">Job ID : </label>
    <select class="form-control" style="width: 160px" name="job_id">
        <option value="{{ $job_id }}">{{ $job_id }}</option>
        @foreach($jobs as $job)
            <option value= {{$job->JobId}} > {{$job->JobId}} </option>
        @endforeach
    </select>

    <label class="px-2">From :</label>
    <input type="date" style="width: 195px" name="date" value="{{ $date }}" class="form-control">

    <label class="px-2">To :</label>
    <input type="date" style="width: 195px" name="date_to" value="{{ $date_to }}" class="form-control">

    <button class="btn btn-outline-primary" type="submit">Apply Filter</button>
</form>
