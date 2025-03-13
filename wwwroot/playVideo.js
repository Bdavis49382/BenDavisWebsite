function setVideoAttributes() {
    const videos = document.querySelectorAll('.video');
    console.log(videos);
    videos.forEach(video => {
        video.autoplay = true;
        video.muted = true;
        video.play();
        console.log('video found');
    })
}

