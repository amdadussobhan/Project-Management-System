<form class="form-inline justify-content-center" action="{{ route('reader_new_call') }}" method="GET">

    <label class="px-2">Follower : </label>
    <select class="form-control" style="width: 130px" name="user_id">
        <option value=""></option>
        @foreach($users as $user)
            <option value="{{$user->id}}"> {{$user->name}} </option>
        @endforeach
    </select>

    <label class="px-2">Possibility : </label>
    <select class="form-control" style="width: 130px" name="possibility_id">
        <option value=""></option>
        @foreach($possibilities as $possibility)
            <option value="{{$possibility->id}}"> {{$possibility->name}} </option>
        @endforeach
    </select>

    <label class="px-1">Country : </label>
    <select class="form-control" style="width: 130px" name="country_id">
        <option value=""></option>
        @foreach($countries as $country)
            <option value="{{$country->id}}"> {{$country->name}} </option>
        @endforeach
    </select>

    <label class="px-2">Catagory : </label>
    <select class="form-control" style="width: 130px" name="category_id">
        <option value=""></option>
        @foreach($categories as $category)
            <option value="{{$category->id}}"> {{$category->name}} </option>
        @endforeach
    </select>

    <label class="px-2">From :</label>
    <input type="date" style="width: 175px" name="date" value="" class="form-control">

    <label class="px-2">To :</label>
    <input type="date" style="width: 175px" name="date_to" value="" class="form-control">

    <button class="btn btn-outline-primary" type="submit">Apply Filter</button>

</form>
