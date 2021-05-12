import React, { useEffect } from "react";
import { useStore } from "../../app/stores/store";
import ProfileFeed from "./ProfileFeed";
import ProfileHeader from "./ProfileHeader";

export default function Profile() {
  const { consultantStore } = useStore();
  const {reviewStore}=useStore();
  const {postStore}=useStore();

  useEffect(()=>{
    reviewStore.getReviewsForSelectedConsultant(consultantStore.selectedConsultant);
    postStore.getListOfPostsForSelectedConsultant(consultantStore.selectedConsultant);
  },[])

  return (
    <div>
      <ProfileHeader />
      <ProfileFeed />
    </div>
  );
}
