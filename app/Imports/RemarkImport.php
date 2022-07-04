<?php

namespace App\Imports;

use App\Remark;
use Maatwebsite\Excel\Concerns\ToModel;

class RemarkImport implements ToModel
{
    public function model(array $row)
    {
        return new Remark([
            'user_id'    => $row[0],
            'status_id'    => $row[1],
            'category_id'    => $row[2],
            'company'    => $row[3],
            'country'    => $row[4],
            'website'    => $row[5],
            'contact_person'    => $row[6],
            'designation'    => $row[7],
            'phone'    => $row[8],
            'email'    => $row[9],
            'description'    => $row[10],
            'created_at'    => $row[11],
        ]);
    }
}
