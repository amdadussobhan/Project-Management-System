<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateShiftReportsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('shift_reports', function (Blueprint $table) {
            $table->id();
            $table->integer('SL');
            $table->string('Loc');
            $table->dateTime('Date');
            $table->string('Shift');
            $table->double('Capacity')->nullable();
            $table->double('AchieveLoad')->nullable();
            $table->double('AchieveProTime')->nullable();
            $table->integer('PreFile')->nullable();
            $table->integer('NewFile')->nullable();
            $table->double('PreLoad')->nullable();
            $table->integer('TotalFile')->nullable();
            $table->double('TotalLoad')->nullable();
            $table->integer('HandFile')->nullable();
            $table->double('HandLoad')->nullable();
            $table->integer('ProDone')->nullable();
            $table->integer('QcDone')->nullable();
            $table->integer('Quality')->nullable();
            $table->integer('TargetAchieve')->nullable();
            $table->integer('Efficiency')->nullable();
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
        Schema::dropIfExists('shift_reports');
    }
}
