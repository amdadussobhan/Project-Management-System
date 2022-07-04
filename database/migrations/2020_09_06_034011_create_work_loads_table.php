<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateWorkLoadsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('work_loads', function (Blueprint $table) {
            $table->id();
            $table->integer('SL');
            $table->string('Loc');
            $table->dateTime('Date');
            $table->string('Shift');
            $table->string('JobId');
            $table->dateTime('Incoming');
            $table->dateTime('Delivery');
            $table->integer('File')->nullable();
            $table->double('Time')->nullable();
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
        Schema::dropIfExists('work_loads');
    }
}
