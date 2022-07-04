<?php

namespace App\Exports;

use App\Remark;
use Maatwebsite\Excel\Concerns\FromCollection;

class RemarksExport implements FromCollection
{
    public function collection()
    {
        return Remark::all();
    }
}
