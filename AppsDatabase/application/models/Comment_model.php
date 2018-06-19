<?php
class comment_model extends MY_Model{

	protected $_table_name = 'comments';
	protected $_order_by = 'name';

	protected $belongs_to = array('user','feed');
	
	function __construct (){
			parent::__construct();
			$this->_database = $this->db;
	}

	public function getUserComments($user_id){
		$this->db->select('*');
		$this->db->where('feeds.user_id = user_id');
		return $this->get_all();
	}

	public function getPhotoComements($feed_id){
		$this->db->select('*');
		$this->db->from ( 'comments' );
		$this->db->where(array('feed_id' => $feed_id));
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$comments = $query->result();
		   		foreach ($comments as $row){
		   			//get comments for each post
		   			$user = $this->getFeedUser($row->user_id);
		   			$row->user = $user;
		   		}
		   		return $comments;
		}else{
			$empty = array();
			return $empty;
		}
	}

	public function getFeedUser($user_id){
		$this->db->select('*');
		$this->db->from ( 'users' );
		$this->db->where(array('users.id' => $user_id));
		$query = $this->db->get();
		return $query->row();
	}

		public function getPhotoCommentss($feed_id){
		$this->db->select('*,
			(select username from users where comments.user_id = users.id) as username
			');
		$this->db->where('comments.feed_id = feed_id');
		return $this->get_all();
	}
}