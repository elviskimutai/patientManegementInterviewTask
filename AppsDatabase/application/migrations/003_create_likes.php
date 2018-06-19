<?php
class Migration_Create_likes extends CI_Migration {

	public function up()
	{
		$this->dbforge->add_field(array(
			'id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
				'auto_increment' => TRUE
		),
			'user_id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
		),
			'feed_id' => array(
				'type' => 'INT',
				'constraint' => 11,
				'unsigned' => TRUE,
		)

		));
		$this->dbforge->add_key('id');
		$this->dbforge->create_table('likes');
	}

	public function down()
	{
		$this->dbforge->drop_table('likes');
	}
}