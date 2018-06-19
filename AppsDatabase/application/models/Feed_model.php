<?php
class feed_model extends MY_Model{

	protected $_table_name = 'feeds';

	protected $belongs_to = array('user');

	protected $has_many = array('comments'=>array('primary_key'=>'feed_id','model'=>'comment_model'),'likes'=>array('primary_key'=>'feed_id','model'=>'like_model'));
	
	function __construct (){
			parent::__construct();
			$this->_database = $this->db;
	}

	public function getUserFeedsCount($user_id){
		$this->db->select ( '*' );
		$this->db->from ( $this->_table_name );
		$this->db->where(array('user_id' => $user_id));
		$query = $this->db->get();
		$total = count($query->result());
		return $total;
	}

		public function getUserFollowingFeeds($user_id){
		$this->db->select('feeds.*,
			(select count(user_id) from likes where likes.feed_id=feeds.id ) as number_of_likes,
			(select count(user_id) from comments where comments.feed_id=feeds.id ) as number_of_comments
			');
		$this->db->from ( 'feeds' );
		$this->db->join('followers', ' feeds.user_id = followers.followed_id','left'); 
		$this->db->where(array('followers.follower_id' => $user_id));
		$this->db->or_where(array('feeds.user_id' => $user_id));
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$feeds = $query->result();
		   		foreach ($feeds as $row){
		   			//get comments for each post
		   			$user = $this->getUser($row->user_id);
		   			$comment = $this->getFeedComments($row->id);
		   			$like = $this->getFeedLikes($row->id);
		   			if (count($this->checkIfUserHasLiked($user_id, $user->id, $row->id))>=1) {
		   				$row->liked = 'true';
		   			}else{
						$row->liked = 'false';
		   			}
		   			$row->user = $user;
		   			$row->comments = $comment;
		   			$row->likes = $like;
		   		}
		   		return $feeds;
		}else{
			$empty = array();
			return $empty;
		}
		
	}
	public function getInvestmentFeeds($user_id){
		$this->db->select('feeds.*,
			(select count(user_id) from likes where likes.feed_id=feeds.id ) as number_of_likes,
			(select count(user_id) from comments where comments.feed_id=feeds.id ) as number_of_comments
			');
		$this->db->from ( 'feeds' );
		$this->db->join('followers', ' feeds.user_id = followers.followed_id','left'); 
		$this->db->where(array('followers.follower_id' => $user_id));
		$this->db->or_where(array('feeds.user_id' => $user_id));
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$feeds = $query->result();
		   		foreach ($feeds as $row){
		   			//get comments for each post
		   			$user = $this->getUser($row->user_id);
		   			$comment = $this->getFeedComments($row->id);
		   			$like = $this->getFeedLikes($row->id);
		   			if (count($this->checkIfUserHasLiked($user_id, $user->id, $row->id))>=1) {
		   				$row->liked = 'true';
		   			}else{
						$row->liked = 'false';
		   			}
		   			$row->user = $user;
		   			$row->comments = $comment;
		   			$row->likes = $like;
		   		}
		   		return $feeds;
		}else{
			$empty = array();
			return $empty;
		}
		
	}

	public function getUserFeeds($user_id){
		$this->db->select('*,
			(select count(user_id) from likes where likes.feed_id=feeds.id ) as number_of_likes,
			(select count(user_id) from comments where comments.feed_id=feeds.id ) as number_of_comments
			');
		$this->db->from ( 'feeds' );
		$this->db->where(array('user_id' => $user_id));
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$feeds = $query->result();
		   		foreach ($feeds as $row){
		   			//get comments for each post
		   			$user = $this->getUser($row->user_id);
		   			$comment = $this->getFeedComments($row->id);
		   			$like = $this->getFeedLikes($row->id);
		   			if (count($this->checkIfUserHasLiked($user_id, $user->id, $row->id))>=1) {
		   				$row->liked = 'true';
		   			}else{
						$row->liked = 'false';
		   			}
		   			$row->user = $user;
		   			$row->comments = $comment;
		   			$row->likes = $like;
		   		}
		   		return $feeds;
		}else{
			$empty = array();
			return $empty;
		}
		
	}
	public function searchFeeds($user_id, $search_term){
		$this->db->select('*,
			(select count(user_id) from likes where likes.feed_id=feeds.id ) as number_of_likes,
			(select count(user_id) from comments where comments.feed_id=feeds.id ) as number_of_comments
			');
		$this->db->from ( 'feeds' );
		//$this->db->where('feeds.user_id', $user_id);
		$this->db->like('feeds.caption', $search_term);
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$feeds = $query->result();
		   		foreach ($feeds as $row){
		   			//get comments for each post
		   			$user = $this->getUser($row->user_id);
		   			$comment = $this->getFeedComments($row->id);
		   			$like = $this->getFeedLikes($row->id);
		   			if (count($this->checkIfUserHasLiked($user_id, $user->id, $row->id))>=1) {
		   				$row->liked = 'true';
		   			}else{
						$row->liked = 'false';
		   			}
		   			$row->user = $user;
		   			$row->comments = $comment;
		   			$row->likes = $like;
		   		}
		   		return $feeds;
		}else{
			$empty = array();
			return $empty;
		}
		
	}

	public function getFeed($feed_id, $user_id){
		$this->db->select('*,
			(select count(user_id) from likes where likes.feed_id=feeds.id ) as number_of_likes,
			(select count(user_id) from comments where comments.feed_id=feeds.id ) as number_of_comments
			');
		$this->db->from ( 'feeds' );
		//$this->db->where('feeds.user_id', $user_id);
		$this->db->where(array('feeds.id' => $feed_id));
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$feeds = $query->row();
		   			//get comments for each post
		   			$user = $this->getUser($feeds->user_id);
		   			$comment = $this->getFeedComments($feeds->id);
		   			$like = $this->getFeedLikes($feeds->id);
		   			if (count($this->checkIfUserHasLiked($user_id, $user->id, $feeds->id))>=1) {
		   				$feeds->liked = 'true';
		   			}else{
						$feeds->liked = 'false';
		   			}
		   			$feeds->user = $user;
		   			$feeds->comments = $comment;
		   			$feeds->likes = $like;
		   		return $feeds;
		}else{
			$empty = array();
			return null;
		}
		
	}

	public function getUserLikes($user_id){
		$this->db->select('*,
			(select count(user_id) from likes where likes.feed_id=feeds.id ) as number_of_likes,
			(select count(user_id) from comments where comments.feed_id=feeds.id ) as number_of_comments
			');
		$this->db->from ( 'feeds' );
		$this->db->where(array('feeds.user_id' => $user_id));
		$this->db->where(array('likes.user_id' => $user_id));
		$this->db->join('likes', ' feeds.id = likes.feed_id','left'); 
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$feeds = $query->result();
		   		foreach ($feeds as $row){
		   			//get comments for each post
		   			$user = $this->getUser($user_id);
		   			$comment = $this->getFeedComments($row->id);
		   			$like = $this->getFeedLikes($row->id);
		   			if (count($this->checkIfUserHasLiked($user_id, $user->id, $row->id))>=1) {
		   				$row->liked = 'true';
		   			}else{
						$row->liked = 'false';
		   			}
		   			$row->user = $user;
		   			$row->comments = $comment;
		   			$row->likes = $like;
		   		}
		   		return $feeds;
		}else{
			$empty = array();
			return $empty;
		}	
	}

	public function getUser($id){
		$this->db->select ( '*' );
		$this->db->from ( "users" );
		$this->db->where(array('id' => $id));
		$query = $this->db->get();
		return $query->row();
	}

	public function getFeedComments($feed_id){
		$this->db->select ( '*' );
		$this->db->from ( 'comments' );
		$this->db->where(array('feed_id' => $feed_id));
		$this->db->distinct();
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$comments = $query->result();
		   		foreach ($comments as $row){
		   			//get comments for each post
		   			$user = $this->getCommentUser($row->user_id);
		   			$row->user = $user;
		   		}
		   		return $comments;
		}else{
			$empty = array();
			return $empty;
		}
	}

	public function getCommentUser($user_id){
		$this->db->select('*');
		$this->db->from ( 'users' );
		$this->db->where(array('users.id' => $user_id));
		$query = $this->db->get();
		return $query->row();
	}


	public function getFeedLikes($feed_id){
		$this->db->select ( '*' );
		$this->db->from ( 'likes' );
		$this->db->where(array('feed_id' => $feed_id));
		$this->db->distinct();
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$likes = $query->result();
		   		foreach ($likes as $row){
		   			//get likes for each post
		   			$user = $this->getLikeUser($row->user_id);
		   			$row->user = $user;
		   		}
		   		return $likes;
		}else{
			$empty = array();
			return $empty;
		}
	}

	public function getLikeUser($user_id){
		$this->db->select('*');
		$this->db->from ( 'users' );
		$this->db->where(array('users.id' => $user_id));
		$query = $this->db->get();
		return $query->row();
	}

	public function checkIfUserHasLiked($user, $photo_owner_id, $feed_id){
		$this->db->select ( '*' );
		$this->db->from ( 'likes' );
		$this->db->where(array('user_id' => $user));
		$this->db->where(array('feed_id' => $feed_id));
		$this->db->where(array('photo_owner_id' => $photo_owner_id));
		$query = $this->db->get();
		return $query->result();
	}
	
	public function getExploreFeeds(){
		return $this->get_all();
	}

	public function getHotFeeds($user_id){
		$this->db->select('*,
			(select count(user_id) from likes where likes.feed_id=feeds.id ) as number_of_likes,
			(select count(user_id) from comments where comments.feed_id=feeds.id ) as number_of_comments
			');
		$this->db->from ( 'feeds' );
		$this->db->order_by("number_of_likes", "desc");
		$this->db->order_by("number_of_comments", "desc");
		$query = $this->db->get();
		$data = array();
		if ($query->num_rows() > 0){
			$feeds = $query->result();
		   		foreach ($feeds as $row){
		   			//get comments for each post
		   			$user = $this->getUser($row->user_id);
		   			$comment = $this->getFeedComments($row->id);
		   			$like = $this->getFeedLikes($row->id);
		   			if (count($this->checkIfUserHasLiked($user_id, $user->id, $row->id))>=1) {
		   				$row->liked = 'true';
		   			}else{
						$row->liked = 'false';
		   			}
		   			$row->user = $user;
		   			$row->comments = $comment;
		   			$row->likes = $like;
		   		}
		   		return $feeds;
		}else{
			$empty = array();
			return $empty;
		}
	}
}