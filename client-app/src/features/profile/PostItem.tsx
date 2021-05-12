import React from "react";
import { Input, Item, Segment } from "semantic-ui-react";
import { Post } from "../../app/models/post";

interface Props {
  post: Post;
}

export default function PostItem({ post }: Props) {
  return (
    <div>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image
              size="tiny"
              circular
              src={require("../../images/homersimpson.0.0.jpg")}
              alt="photo"
            />
            <Item.Content>
              <Item.Header>{post.title}</Item.Header>
              <Item.Description>{post.description}</Item.Description>
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
    </div>
  );
}
