<?php
class Like extends CI_Controller
{

	public function __construct ()
	{
		parent::__construct();
		$this->load->model('like_model');
		$this->load->model('feed_model');
	}

	public function likePhoto(){

		$like = array(
		"user_id" => $this->input->post('user_id'),
		"feed_id" => $this->input->post('feed_id'),
		"photo_owner_id" => $this->input->post('photo_owner_id')
		);

		$data = $this->like_model->like($like);
		$feed = array();

		if( $data != false) {
				$feed['message'] = 'Success';
				$feed['success'] = true;
				//$feed['post'] = $this->like_model->get($data);
			
		}else{
			$feed['success'] = false;
			$feed['message'] = 'You\'ve already liked this photo';
			//$feed['feed'] = array();
		}

		echo json_encode($feed);
	}


	public function unLikePhoto(){

		$like = array(
		"user_id" => $this->input->post('user_id'),
		"feed_id" => $this->input->post('feed_id'),
		"photo_owner_id" => $this->input->post('photo_owner_id')
		);
	
		$data = $this->like_model->unLike($like);
		$feed = array();

		if( $data == true) {
				$feed['message'] = 'Success';
				$feed['success'] = $data;
			
		}else if ($data == false) {
			$feed['success'] = false;
			$feed['message'] = 'You\'ve already unLiked this photo';
		}else{
			$feed['success'] = $data;
			$feed['message'] = 'Something went wrong';
		}

		echo json_encode($feed);
	}

	public function userLikes(){

		$user_id = $this->input->post('user_id');

		$data = $this->feed_model->getUserLikes($user_id);
		$feed = array();

		if( $data != false) {
				$feed['message'] = 'Success';
				$feed['success'] = true;
				$feed['likes'] = $data;
			
		}else{
			$feed['success'] = false;
			$feed['message'] = 'User have not liked any photo';
			$feed['likes'] = array();
		}

		echo json_encode($feed);
	}
	
}

	