<form class="form-inline justify-content-center" action="" method="GET">

    <label class="px-2">Team : </label>
    <select class="form-control" style="width: 160px" name="team">
        <option value="{{ $team }}">{{ $team }}</option>
        <option value="All Team"> All Team </option>
    </select>

    <label class="px-2">Name : </label>
    <select class="form-control" style="width: 160px" name="designer">
        <option value="{{ $designer }}">{{ $designer }}</option>
        <option value="All Designer"> All Designer </option>        
        @if($designers != null)
            @foreach($designers as $designer)
                <option value= {{$designer->Name}} > {{$designer->Name}} </option>
            @endforeach
        @endif
    </select>

    <label class="px-2">User ID : </label>
    <select class="form-control" style="width: 160px" name="user_id">
        <option value="{{ $user_id }}">{{ $user_id }}</option>
        <option value="All User"> All User </option>
        @if($users != null)
            @foreach($users as $user)
                <option value= {{$user->id}} > {{$user->name}} </option>
            @endforeach
        @endif
    </select>

    <button class="btn btn-outline-primary" type="submit">Apply Filter</button>
</form>
