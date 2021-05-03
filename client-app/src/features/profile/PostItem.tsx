import React from "react";
import { Item, Segment } from "semantic-ui-react";

export default function PostItem() {
  return (
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
            <Item.Header>Post title</Item.Header>
            <Item.Description>Post description</Item.Description>
          </Item.Content>
        </Item>
      </Item.Group>
    </Segment>
  );
}
