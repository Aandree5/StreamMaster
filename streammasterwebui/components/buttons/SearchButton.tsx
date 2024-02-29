import BaseButton from './BaseButton';
import { ChildButtonProperties } from './ChildButtonProperties';

const SearchButton: React.FC<ChildButtonProperties> = ({ disabled = false, onClick, tooltip = 'Add' }) => (
  <BaseButton disabled={disabled} icon="pi-search-plus" iconFilled={false} onClick={onClick} severity="success" tooltip={tooltip} />
);

export default SearchButton;
