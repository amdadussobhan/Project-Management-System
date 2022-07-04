<form class="form-inline justify-content-center" action="{{ route('reader_workloads') }}" method="GET">

    <label class="px-2">Shift : </label>
    <select class="form-control" style="width: 110px" name="shift">
        <option value="{{ $shift }}">{{ $shift }}</option>
        <option value="Morning"> Morning </option>
        <option value="Evening"> Evening </option>
        <option value="Night"> Night </option>
    </select>

    <label class="px-2">From :</label>
    <input type="date" style="width: 180px" name="date" value="{{ $date }}" class="form-control">

    <label class="px-2">To :</label>
    <input type="date" style="width: 180px" name="date_to" value="{{ Request::get('date_to') }}" class="form-control">

    <button class="btn btn-outline-primary" type="submit">Apply Filter</button>
</form>
