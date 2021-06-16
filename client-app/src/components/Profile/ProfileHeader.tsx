import React from "react";
import { Button, Grid, Item, Progress, Segment } from "semantic-ui-react";
import { useStore } from "../../stores/store";
import HomerImage from "../../assets/homersimpson.0.0.jpg";

export default function ProfileHeader() {
  const { consultantStore } = useStore();

  return (
    <div>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image src={HomerImage} size="small" />
            <Item.Content>
              <Grid>
                <Grid.Row>
                  <Grid.Column width="6">
                    <Item.Group>
                      <Item>
                        <Item.Header>
                          {consultantStore.selectedConsultant?.displayName}
                        </Item.Header>
                      </Item>
                    </Item.Group>
                    <Item.Description>
                      {consultantStore.selectedConsultant?.bio}
                    </Item.Description>
                    <Progress
                      percent={50}
                      style={{ width: "17em", marginBottom: "4em" }}
                      success
                    >
                      {consultantStore.selectedConsultant?.categories[0]} Level:{" "}
                      {4}
                    </Progress>
                  </Grid.Column>
                  <Grid.Column verticalAlign="middle" width="4">
                    <Item.Content
                      style={{
                        fontSize: "xx-large",
                        fontStyle: "bold",
                      }}
                    >
                      125 Followers
                    </Item.Content>
                  </Grid.Column>
                  <Grid.Column verticalAlign="middle" width="6">
                    <Item.Content
                      style={{ fontSize: "xx-large", fontStyle: "bold" }}
                    >
                      14 Following
                    </Item.Content>
                  </Grid.Column>
                </Grid.Row>
              </Grid>
              <Button.Group widths="2">
                <Button floated="right" positive>
                  Hire
                </Button>
                <Button floated="right" primary>
                  Follow
                </Button>
              </Button.Group>
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
    </div>
  );
}
