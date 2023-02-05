import * as React from 'react';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { connect } from 'react-redux';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import Divider from '@mui/material/Divider';
import Container from '@mui/material/Container';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import DashboardIcon from '@mui/icons-material/Dashboard';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import PlayersListWrapper from './playersList/PlayersListWrapper';
import { initGetPlayers as initGetPlayersAction } from '../actions';

const mdTheme = createTheme();

class Dashboard extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      selectedItem: '',
    };
    this.props.initGetPlayers();
  }

  handleListItemClick = (event, selectedItemName) => {
    this.setState({ selectedItem: selectedItemName });
  };

  render() {
    return (
      <ThemeProvider theme={mdTheme}>
        <Box sx={{ display: 'flex' }}>
          <List component="nav">
            <ListItemButton
              selected={this.selectedItem === 'Players'}
              onClick={event => this.handleListItemClick(event, 'Players')}
            >
              <ListItemIcon>
                <DashboardIcon />
              </ListItemIcon>
              <ListItemText primary="Players" />
            </ListItemButton>
            <ListItemButton
              selected={this.selectedItem === 'Team'}
              onClick={event => this.handleListItemClick(event, 'Team')}
            >
              <ListItemIcon>
                <ShoppingCartIcon />
              </ListItemIcon>
              <ListItemText primary="Team" />
            </ListItemButton>
            <Divider sx={{ my: 1 }} />
          </List>
          <Box
            component="main"
            sx={{
              backgroundColor: theme => theme.palette.grey[100],
              flexGrow: 1,
              height: '100vh',
              overflow: 'auto',
            }}
          >
            <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
              <Grid>
                <Grid>
                  <Paper sx={{ p: 2, display: 'flex', flexDirection: 'column' }}>
                    {this.state.selectedItem !== '' && (
                      <PlayersListWrapper type={this.state.selectedItem} />
                    )}
                  </Paper>
                </Grid>
              </Grid>
            </Container>
          </Box>
        </Box>
      </ThemeProvider>
    );
  }
}

const mapDispatchToProps = dispatch => ({
  initGetPlayers: () => dispatch(initGetPlayersAction()),
});

export default connect(null, mapDispatchToProps)(Dashboard);
