<form class="form-inline justify-content-center" action="{{ route('reader_dashboard') }}" method="GET">

    <label class="px-2">Team : </label>
    <select class="form-control" style="width: 130px" name="team">
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

    <label class="px-2">Shift : </label>
    <select class="form-control" style="width: 130px" name="shift">
        <option value="{{ $shift }}">{{ $shift }}</option>
        <option value="Morning"> Morning </option>
        <option value="Evening"> Evening </option>
        <option value="Night"> Night </option>
    </select>

    <label class="px-2">To :</label>
    <input type="date" style="width: 175px" name="date" value="{{ $date }}" class="form-control">

    <button class="btn btn-outline-primary" type="submit">Apply Filter</button>
</form>
