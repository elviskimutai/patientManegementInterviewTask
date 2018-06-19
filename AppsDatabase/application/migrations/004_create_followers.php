<?php
class Migration_Create_followers extends CI_Migration {

	public function up()
	{
		$this->dbforge->add_field(array(
			'id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
				'auto_increment' => TRUE
		),
			'follower_id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
		),
			'followed_id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
		)

		));
		$this->dbforge->add_key('id');
		$this->dbforge->create_table('followers');
	}

	public function down()
	{
		$this->dbforge->drop_table('followers');
	}
}