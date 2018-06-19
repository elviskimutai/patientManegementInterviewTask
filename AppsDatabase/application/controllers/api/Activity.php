<?php
class Activity extends CI_Controller
{

	public function __construct ()
	{
		parent::__construct();
		$this->load->model('follower_model');
		$this->load->model('like_model');
	}


		public function follow(){
		$follow = array(
			"follower_id" => $this->input->post('follower_id'),
			"followed_id" => $this->input->post('followed_id')
		);


		$data = $this->follower_model->follow($follow);
		$feed = array();

		if( $data=='Already following') {
			$feed['success'] = false;
			$feed['message'] = 'Already following the user';
			$feed['feed'] = array();
			
		}else{
			$feed['message'] = 'Success';
			$feed['success'] = true;
			$feed['follow'] = $this->follower_model->get($data);
			
		}

		echo json_encode($feed);
	}

	public function followersCount(){
		$followed_id = $this->input->post('user_id');
		$data = $this->follower_model->getUserFollowersCount($followed_id);
		$feed = array();

		if( $data != 0) {
			$feed['success'] = true;
			$feed['message'] = 'Success';
			$feed['followers'] = $data;
			
		}else{
			$feed['message'] = 'Failure';
			$feed['success'] = false;
			$feed['followers'] = array();
			
		}

		echo json_encode($feed);
	}

	public function followingCount(){
		$followed_id = $this->input->post('user_id');
		$data = $this->follower_model->getUserFollowingCount($followed_id);
		$feed = array();

		if( $data != 0) {
			$feed['success'] = true;
			$feed['message'] = 'Success';
			$feed['following'] = $data;
			
		}else{
			$feed['message'] = 'Failure';
			$feed['success'] = false;
			$feed['following'] = array();
			
		}

		echo json_encode($feed);
	}
	public function followers(){
		$followed_id = $this->input->post('user_id');
		$data = $this->follower_model->getUserFollowers($followed_id);
		$feed = array();

		if( $data != 0) {
			$feed['success'] = true;
			$feed['message'] = 'Success';
			$feed['followers'] = $data;
			
		}else{
			$feed['message'] = 'Failure';
			$feed['success'] = false;
			$feed['followers'] = array();
			
		}

		echo json_encode($feed);
	}

	public function following(){
		$followed_id = $this->input->post('user_id');
		$data = $this->follower_model->getUserFollowing($followed_id);
		$feed = array();

		if( $data != 0) {
			$feed['success'] = true;
			$feed['message'] = 'Success';
			$feed['following'] = $data;
			
		}else{
			$feed['message'] = 'Failure';
			$feed['success'] = false;
			$feed['following'] = array();
			
		}

		echo json_encode($feed);
	}
}

	