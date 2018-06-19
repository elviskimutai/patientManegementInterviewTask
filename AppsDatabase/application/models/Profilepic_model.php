<?php
class profilepic_model extends MY_Model{

	protected $_table_name = 'profilepics';
	protected $_order_by = 'name';
	
	protected $belongs_to = array('user');
	
	function __construct (){
			parent::__construct();
			$this->_database = $this->db;
		}
}