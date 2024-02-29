import BaseButton from './BaseButton';
import { ChildButtonProperties } from './ChildButtonProperties';

const ClockButton: React.FC<ChildButtonProperties> = ({ disabled = false, label, onClick, tooltip = 'Time Shift', iconFilled }) => (
  <BaseButton disabled={disabled} icon="pi-stopwatch" iconFilled={iconFilled} label={label} onClick={onClick} tooltip={tooltip} />
);

export default ClockButton;
