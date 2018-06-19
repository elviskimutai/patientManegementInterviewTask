<?php
class like_model extends MY_Model{

	protected $_table_name = 'likes';
	protected $_order_by = 'name';
	protected $belongs_to = array('user', 'feed');
	
	function __construct (){
			parent::__construct();
			$this->_database = $this->db;
		}

	public function getFeedId($user, $photo_owner_id, $feed_id){
		$this->db->select ( 'id' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('user_id' => $user));
		$this->db->where(array('feed_id' => $feed_id));
		$this->db->where(array('photo_owner_id' => $photo_owner_id));
		$query = $this->db->get();
		return $query->row()->id;
	}

		public function getFeedByLike($user, $photo_owner_id, $feed_id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('user_id' => $user));
		$this->db->where(array('feed_id' => $feed_id));
		$this->db->where(array('photo_owner_id' => $photo_owner_id));
		$query = $this->db->get();
		return $query->result();
	}

	public function getUserLikes($user_id){
		$this->db->select('feeds.*');
		$this->db->from ( 'likes' );
		$this->db->join('feeds', ' feeds.id = likes.feed_id','left'); 
		$this->db->where(array('likes.user_id' => $user_id));
		$query = $this->db->get();
		return $query->result();
		}
		

		public function like($like){
			if (count($this->getFeedByLike($like['user_id'], $like['photo_owner_id'], $like['feed_id'])) >= 1) {
				return false;
			}else{
				$id = $this->insert($like);
				return true;
			}
		}

		public function unLike($like){
			if (count($this->getFeedByLike($like['user_id'], $like['photo_owner_id'], $like['feed_id'])) >= 1) {
				$id = $this->getFeedId($like['user_id'], $like['photo_owner_id'], $like['feed_id']);
				$this->delete($id);
				return true;
			}else{
				return false;
			}
		}
}