import React from "react";
import { Grid, List } from "semantic-ui-react";
import { Category } from "../../../app/models/category";
import { Post } from "../../../app/models/post";

interface Props{
    categories: Category[];
    posts:Post[];
}

export default function ConsultantDashboard({categories,posts}:Props) {
  return (
    <Grid>
      <Grid.Column width="10">
        <List>
          {posts.map((post) => (
            <List.Item key={post.id}>{post.title}</List.Item>
          ))}
        </List>

        <List>
          {categories.map((category) => (
            <List.Item key={category.id}>{category.name}</List.Item>
          ))}
        </List>
      </Grid.Column>
    </Grid>
  );
}
