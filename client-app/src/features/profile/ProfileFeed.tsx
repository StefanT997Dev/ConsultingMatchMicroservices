import { observer } from "mobx-react-lite";
import React, { useState } from "react";
import {
  Button,
  Grid,
  Input,
  InputOnChangeData,
  Item,
  Segment,
  TextArea,
  TextAreaProps,
} from "semantic-ui-react";
import { Post } from "../../app/models/post";
import { useStore } from "../../app/stores/store";
import PostItem from "./PostItem";
import ReviewItem from "./ReviewItem";
import { v4 as uuid } from "uuid";
import ValidationErrors from "../errors/ValidationErrors";

export default observer(function ProfileFeed() {
  const { reviewStore } = useStore();
  const { postStore } = useStore();
  const { consultantStore } = useStore();

  const [post, setPost] = useState<Post | undefined>(undefined);
  const [postTitle, setPostTitle] = useState<string>("");
  const [postDescription, setPostDescription] = useState<
    string | number | undefined
  >("");

  const handlePostTitleChange = (
    event: React.ChangeEvent<HTMLInputElement>,
    data: InputOnChangeData
  ) => {
    setPostTitle(data.value);
  };

  const handlePostDescriptionChange = (
    event: React.ChangeEvent<HTMLTextAreaElement>,
    data: TextAreaProps
  ) => {
    setPostDescription(data.value);
  };

  return (
    <Grid>
      <Grid.Row>
        <Grid.Column width="10">
          <Segment>
            <Item.Group>
              <Item>
                <Input
                  onChange={handlePostTitleChange}
                  placeholder="Enter post title"
                />
              </Item>
              <TextArea
                onChange={handlePostDescriptionChange}
                style={{ width: "45em", height: "7em" }}
                placeholder="Enter post content"
              />
              <Button
                onClick={() => {
                  postStore.setPost(postTitle, postDescription);
                  postStore.submitAPost(
                    consultantStore.selectedConsultant,
                    postStore.post
                  );
                }}
                primary
              >
                Submit
              </Button>
            </Item.Group>
            {postStore.errors && <ValidationErrors errors={postStore.errors} />}
          </Segment>

          {postStore.posts.map((post) => (
            <PostItem post={post} />
          ))}
        </Grid.Column>
        <Grid.Column width="6">
          {reviewStore.reviewsForSelectedConsultant.map((review) => (
            <ReviewItem review={review} />
          ))}
        </Grid.Column>
      </Grid.Row>
    </Grid>
  );
});
