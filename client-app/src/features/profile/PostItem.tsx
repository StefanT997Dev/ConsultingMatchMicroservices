import React, { useState } from "react";
import { Button, Icon, Input, Item, Label, Segment, TextArea } from "semantic-ui-react";
import { Post } from "../../app/models/post";
import CommentArea from "./CommentArea";
import CommentItem from "./CommentArea";
import PostComment from "./PostComment";

interface Props {
  post: Post;
}

export default function PostItem({ post }: Props) {
  const [displayCommentItem,setDisplayCommentItem]=useState<boolean>(false);
  
  const toggleCommentArea=()=>{
    setDisplayCommentItem(displayCommentItem=>!displayCommentItem);
  }
  
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
              <br></br>
              <Button.Group size="tiny" widths="2">
                <Button as="div" labelPosition="right">
                  <Button color="red">
                    <Icon name="heart" />
                    Give Credits
                  </Button>
                  <Label as="a" basic color="red" pointing="left">
                    2,048
                  </Label>
                </Button>
                <Button onClick={toggleCommentArea} color="green">
                  Comment
                </Button>
              </Button.Group>
            </Item.Content>
          </Item>
          {displayCommentItem?<CommentArea post={post}/>:null}
        </Item.Group>
      </Segment>
    </div>
  );
}
