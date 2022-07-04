<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreatePerformancesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('performances', function (Blueprint $table) {
            $table->id();
            $table->integer('SL');
            $table->string('Loc');
            $table->dateTime('Date');
            $table->dateTime('Login');
            $table->dateTime('Logout');
            $table->string('Shift');
            $table->string('Status');
            $table->string('Name');
            $table->integer('WorkingTime')->nullable();
            $table->integer('File')->nullable();
            $table->double('JobTime')->nullable();
            $table->double('ProTime')->nullable();
            $table->integer('Efficiency')->nullable();
            $table->integer('Quality')->nullable();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('performances');
    }
}
