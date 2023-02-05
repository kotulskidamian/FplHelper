import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import PlayersList from './PlayersList';

const PlayersListWrapper = ({ type, players, teams, playersInMyTeam }) => (
  <>
    {type === 'Players' && <PlayersList type={type} players={players} />}
    {type === 'Team' && <PlayersList type={type} players={playersInMyTeam} />}
  </>
);

const mapStateToProps = ({ fpl, teams, playersInMyTeam }) => {
  const tempPlayersInMyTeam = [
    {
      id: 1,
      first_name: 'Damian',
      second_name: 'Kotulski',
      total_points: 199231,
      value_season: '77',
      now_cost: 99,
    },
  ];

  return {
    players: fpl.players || [],
    teams: teams || [],
    playersInMyTeam: playersInMyTeam || tempPlayersInMyTeam,
  };
};

PlayersListWrapper.propTypes = {
  type: PropTypes.string.isRequired,
  players: PropTypes.arrayOf(
    PropTypes.shape({
      firstName: PropTypes.string.isRequired,
      secondName: PropTypes.string.isRequired,
      selectedByPercent: PropTypes.number.isRequired,
      cost: PropTypes.number.isRequired,
      totalPoints: PropTypes.number.isRequired,
      expectedGoals: PropTypes.number.isRequired,
      expectedAssists: PropTypes.number.isRequired,
      valueSeason: PropTypes.number.isRequired,
    }),
  ).isRequired,
  playersInMyTeam: PropTypes.arrayOf(
    PropTypes.shape({
      first_name: PropTypes.string.isRequired,
      second_name: PropTypes.string.isRequired,
      total_points: PropTypes.number.isRequired,
      value_season: PropTypes.string.isRequired,
      now_cost: PropTypes.number.isRequired,
    }),
  ).isRequired,
};

export default connect(mapStateToProps)(PlayersListWrapper);
