<?php
class Feed extends CI_Controller
{
	protected $has_many = array('comments'=>array('primary_key'=>'feed_id'));


	public function __construct ()
	{
		parent::__construct();
		$this->load->model('feed_model');
		$this->load->helper('url');
	}

	public function createPost(){
		$post = array(
			"user_id" => $this->input->post('user_id'),
			"image_path" => $this->input->post('image_path'),
			"caption" => $this->input->post('caption'),
		);
		$data = $this->feed_model->insert($post);
		$feed = array();

		if( $data != 0) {
				$feed['message'] = 'Success';
				$feed['success'] = true;
				$feed['post'] = $this->feed_model->get($data);
			
		}else{
			$feed['success'] = false;
			$feed['message'] = 'Something went wrong';
			//$feed['feed'] = array();
		}

		echo json_encode($feed);
	}
        public function uploadImage(){
        	
        	$data = $this->input->post('image');
        	$image_name = $this->input->post('image_name');
			$data = base64_decode($data);
		
			$file = 'assets/feeds/'. uniqid() .'_'.$image_name. '.png';
			$image_name = site_url().$file;
			$success = file_put_contents($file, $data);
			
			$feed = array();
		if($success) {

			$feed['message'] = 'Success';
			$feed['success'] = true;
			$feed['image_url'] = $image_name;
			
		}else{
			$feed['success'] = false;
			$feed['message'] = 'Something went wrong';
			//$feed['feed'] = array();
		}

		echo json_encode($feed);
      }


	public function getUserFeeds(){
		$user_id = $this->input->post('user_id');

		$data = $this->feed_model->getUserFeeds($user_id);
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['feeds'] = $data;
		}else{
				$feeds['message'] = 'No User feeds found!';
				$feeds['success'] = false;
				$feeds['feeds'] = null;
		}
		echo json_encode($feeds);
	}

	public function searchTags(){
		$user_id = $this->input->post('user_id');
		$search_term = $this->input->post('search_term');

		$data = $this->feed_model->searchFeeds($user_id, $search_term);
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['feeds'] = $data[0];
		}else{
				$feeds['message'] = 'No feeds found!';
				$feeds['success'] = false;
				$feeds['feeds'] = null;
		}
		echo json_encode($feeds);
	}

	public function getFeed(){
		$feed_id = $this->input->post('feed_id');
		$user_id = $this->input->post('user_id');
		$data = $this->feed_model->getFeed($feed_id, $user_id);
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['feed'] = $data;
		}else{
				$feeds['message'] = 'No feed found';
				$feeds['success'] = false;
				$feeds['feed'] = array();
		}
		echo json_encode($feeds);
	}

	public function getUserFollowingFeeds(){
		$user_id = $this->input->post('user_id');

		$data = $this->feed_model->getUserFollowingFeeds($user_id);
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['feeds'] = $data;
		}else{
				$feeds['message'] = 'No feeds found!';
				$feeds['success'] = false;
				$feeds['feeds'] = array();
		}
		echo json_encode($feeds);
	}
	public function getInvestmentFeeds(){
		$user_id = $this->input->post('user_id');

		$data = $this->feed_model->getInvestmentFeeds($user_id);
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['feeds'] = $data;
		}else{
				$feeds['message'] = 'No feeds found!';
				$feeds['success'] = false;
				$feeds['feeds'] = array();
		}
		echo json_encode($feeds);
	}
	
	public function getExploreFeeds(){
		$data = $this->feed_model->getExploreFeeds();
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['feeds'] = $data;
		}else{
				$feeds['message'] = 'No feeds found!';
				$feeds['success'] = false;
				$feeds['feeds'] = array();
		}
		echo json_encode($feeds);
	}

	public function getHotFeeds(){
		$user_id = $this->input->post('user_id');
		$data = $this->feed_model->getHotFeeds($user_id);
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['feeds'] = $data;
		}else{
				$feeds['message'] = 'No feeds found!';
				$feeds['success'] = false;
				$feeds['feeds'] = array();
		}
		echo json_encode($feeds);
	}

	public function getUserFeedsCount(){
		$user_id = $this->input->post('user_id');
		$data = $this->feed_model->getUserFeedsCount($user_id);
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['posts'] = $data;
		}else{
				$feeds['message'] = 'No feeds found!';
				$feeds['success'] = false;
				$feeds['posts'] = array();
		}
		echo json_encode($feeds);
	}

}