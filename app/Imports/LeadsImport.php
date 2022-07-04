<?php

namespace App\Imports;

use App\Lead;
use Maatwebsite\Excel\Concerns\ToModel;

class LeadsImport implements ToModel
{
    public function model(array $row)
    {
        return new Lead([
            'id'    => $row[0],
            'user_id'    => $row[1],
            'status_id'    => $row[2],
            'category_id'    => $row[3],
            'possibility_id'    => $row[4],
            'country_id'    => $row[5],
            'follower'    => $row[6],
            'company'    => $row[7],
            'website'    => $row[8],
            'contact_person'    => $row[9],
            'designation'    => $row[10],
            'phone'    => $row[11],
            'email'    => $row[12],
            'description'    => $row[13],
            'next_followup'    => $row[14],
            'isdeleted'    => $row[15],
            'isprivate'    => $row[16],
            'created_at'    => $row[17],
            'updated_at'    => $row[18],
        ]);
    }
}
