import { observer } from "mobx-react-lite";
import React from "react";
import { Grid, Item, Label, Rating, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import PostItem from "./PostItem";
import ReviewItem from "./ReviewItem";

export default observer(function ProfileFeed() {
  const { reviewStore } = useStore();

  return (
    <Grid>
      <Grid.Row>
        <Grid.Column width="10">
          <PostItem/>
        </Grid.Column>
        <Grid.Column width="6">
            {reviewStore.reviewsForSelectedConsultant.map(review=>(
                <ReviewItem 
                    review={review}
                />
            ))}
        </Grid.Column>
      </Grid.Row>
    </Grid>
  );
})
